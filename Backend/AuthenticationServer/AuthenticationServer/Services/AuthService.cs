using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationServer.Data;
using AuthenticationServer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedModels.Hasher;
using SharedModels.Models;
using SharedModels.Interface;

namespace AuthenticationServer.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(LoginDto loginDto)
        {
            Guid? accountTypeId = null;
            Guid? userId = null;
            object user = null;

            // Retrieve the user (either Admin or VisitorAccount)
            if (loginDto.IsAdmin)
            {
                user = await _context.Admins.FirstOrDefaultAsync(a => a.Username == loginDto.Username.ToLower());
            }
            else
            {
                user = await _context.VisitorAccounts.FirstOrDefaultAsync(v => v.Username == loginDto.Username.ToLower());
            }

            if (user == null)
            {
                return "Invalid credentials.";
            }

            
            if (user is IAccountLockout lockoutUser)
            {
                if (lockoutUser.LockoutEnd.HasValue && lockoutUser.LockoutEnd > DateTime.UtcNow)
                {
                    return "Account is locked. Please try again later.";
                }
            }

            var hashedPassword = Hasher.HashPassword(loginDto.Password);

            if (user is Admin admin)
            {
                if (admin.Password != hashedPassword)
                {
                    return await HandleFailedLoginAttempt(admin);
                }

                accountTypeId = admin.AccountTypeId;
                userId = admin.Id;
            }
            else if (user is VisitorAccount visitorAccount)
            {
                if (visitorAccount.Password != hashedPassword)
                {
                    return await HandleFailedLoginAttempt(visitorAccount);
                }

                // Check if account has expired
                if (visitorAccount.EndDate.Date < DateTime.UtcNow.Date)
                {
                    return "Account has expired.";
                }

                accountTypeId = visitorAccount.AccountTypeId;
                userId = visitorAccount.Id;
            }

            
            if (user is IAccountLockout resetLockoutUser)
            {
                resetLockoutUser.FailedLoginAttempts = 0;
                resetLockoutUser.LockoutEnd = null;
                await _context.SaveChangesAsync();
            }

            
            var role = await _context.AccountTypes.FindAsync(accountTypeId);
            if (role == null)
            {
                return "Role not found.";
            }

            var jwtSecret = _configuration["JwtSettings:Secret"];
            var key = Encoding.UTF8.GetBytes(jwtSecret);

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role.Name)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  // Return the token
        }

        private async Task<string> HandleFailedLoginAttempt(IAccountLockout user)
        {
            if (user.FailedLoginAttempts >= 5)
            {
                if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow)
                {
                    return "Account is locked. Please try again later.";
                }
                else
                {
                    
                    user.FailedLoginAttempts = 0;
                }
            }

            user.FailedLoginAttempts++;

            if (user.FailedLoginAttempts >= 5)
            {
                user.LockoutEnd = DateTime.UtcNow.AddMinutes(5);
            }

            await _context.SaveChangesAsync();
            return "Invalid credentials.";
        }



    }
}
