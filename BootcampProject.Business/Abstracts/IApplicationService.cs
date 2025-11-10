using BootcampProject.Business.DTOs.Requests;
using BootcampProject.Business.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampProject.Business.Abstracts
{
    public interface IApplicationService
    {
        Task<List<ApplicationResponse>> GetAllAsync();
        Task<ApplicationResponse> GetByIdAsync(int id);
        Task AddAsync(CreateBootcampRequest request);
        Task UpdateAsync(UpdateBootcampRequest request);
        Task DeleteAsync(int id);
    }
}
