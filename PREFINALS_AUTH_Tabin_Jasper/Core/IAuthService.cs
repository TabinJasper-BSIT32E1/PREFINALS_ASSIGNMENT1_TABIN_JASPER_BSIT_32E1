using System.Threading.Tasks;

namespace AuthServer.Core
{
    public interface IAuthService
    {
        // Generate token using username (assuming username + password lookup)
        Task<string> GenerateJwtTokenAsync(string username, string password);

        // Generate token using User object (assuming user object already retrieved)
        Task<string> GenerateJwtTokenAsync(User user);
    }
}
