using RestApp.Domain.Model;
using System.Threading.Tasks;

namespace RestApp.Domain.Services
{
    public interface IAuthService
    {
        Task<TokenResult> GenerateToken(TokenRequest request);
    }
}
