using BootcampProject.Business.DTOs.Requests;
using BootcampProject.Business.DTOs.Responses;
using System.Threading.Tasks;

namespace BootcampProject.Business.Abstracts
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
