using System.Threading.Tasks;

namespace AuthServer.Core
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(string username);

    }
}