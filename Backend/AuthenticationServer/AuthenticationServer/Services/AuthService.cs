using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationServer.Data;
using AuthenticationServer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedModels.Hasher;

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

            //Hash provided DTO password
            var hashedPassword = Hasher.HashPassword(loginDto.Password);

            if (loginDto.IsAdmin)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(a =>
                    a.Username == loginDto.Username && a.Password == hashedPassword
                );

                if (admin == null)
                {
                    return null;
                }

                accountTypeId = admin.AccountTypeId;
                userId = admin.Id;
            }
            else
            {
                var visitorAccount = await _context.VisitorAccounts.FirstOrDefaultAsync(v =>
                    v.Username == loginDto.Username && v.Password == hashedPassword
                );

                if (visitorAccount == null)
                {
                    return null;
                }

                accountTypeId = visitorAccount.AccountTypeId;
                userId = visitorAccount.Id;
            }

            // Retrieve the account role
            var role = await _context.AccountTypes.FindAsync(accountTypeId);
            if (role == null)
            {
                return null;
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
            return tokenHandler.WriteToken(token);
        }
    }
}
