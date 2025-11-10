using BootcampProject.Business.Abstracts;
using BootcampProject.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BootcampProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bootcampService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bootcampService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBootcampRequest request)
        {
            await _bootcampService.AddAsync(request);
            return Ok("Bootcamp oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBootcampRequest request)
        {
            await _bootcampService.UpdateAsync(request);
            return Ok("Bootcamp güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bootcampService.DeleteAsync(id);
            return Ok("Bootcamp silindi.");
        }
    }
}
