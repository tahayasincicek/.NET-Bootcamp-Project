using BootcampProject.Business.Abstracts;
using BootcampProject.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BootcampProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicationService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _applicationService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApplicationRequest request)
        {
            await _applicationService.AddAsync(request);
            return Ok("Başvuru başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationRequest request)
        {
            await _applicationService.UpdateAsync(request);
            return Ok("Başvuru güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _applicationService.DeleteAsync(id);
            return Ok("Başvuru silindi.");
        }
    }
}
