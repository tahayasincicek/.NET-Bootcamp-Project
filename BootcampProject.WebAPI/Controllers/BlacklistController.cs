using BootcampProject.Business.Abstracts;
using BootcampProject.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BootcampProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blacklistService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _blacklistService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlacklistRequest request)
        {
            await _blacklistService.AddAsync(request);
            return Ok("Kullanıcı kara listeye alındı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blacklistService.DeleteAsync(id);
            return Ok("Kara liste kaydı silindi.");
        }
    }
}
