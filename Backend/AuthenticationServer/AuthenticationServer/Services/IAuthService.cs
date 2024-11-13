using AuthenticationServer.DTO;

namespace AuthenticationServer.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(LoginDto loginDto);
    }
}
