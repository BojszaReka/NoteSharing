using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PreferenceController(IUnitOfWork uow) : Controller
    {
        private readonly IUnitOfWork _uow = uow;

        [HttpPost]
        public async Task<IActionResult> AddUserPreference([FromBody] PreferenceViewDTO dto)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.PreferenceRepository.Create(dto); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyUserPreference([FromBody] PreferenceViewDTO dto)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.PreferenceRepository.Update(dto); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUserPreference(Guid id)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.PreferenceRepository.Delete(id); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserPreference(Guid id)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.PreferenceRepository.GetById(id); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }
    }
}
