using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	[AllowAnonymous]
	[Route("/api/[controller]")]
	[ApiController]
	public class PreferenceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PreferenceController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPreference([FromBody] PreferenceViewDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.preferenceRepository.Create(dto);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModifyUserPreference([FromBody] PreferenceViewDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.preferenceRepository.Update(dto);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
            }
            return BadRequest(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUserPreference([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.preferenceRepository.Delete(id);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
            }
            return BadRequest(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserPreference([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.preferenceRepository.GetById(id);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
            }
            return BadRequest(response);
        }
    }
}
