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
	public class InstitutionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public InstitutionController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InstitutionCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.InstitutionRepository.Create(dto);
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
        public async Task<IActionResult> Update([FromBody] InstitutionViewDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.InstitutionRepository.Update(dto);
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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.InstitutionRepository.Delete(id);
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
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.InstitutionRepository.GetById(id);
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.InstitutionRepository.GetAll();
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
