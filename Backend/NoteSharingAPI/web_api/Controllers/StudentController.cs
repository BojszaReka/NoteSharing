using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public StudentController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.studentRepository.GetAll();
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

        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.studentRepository.GetById(id);
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

        [HttpGet("institution/{institutionId:guid}")]
        public async Task<IActionResult> GetStudentsByInstitution([FromRoute] Guid institutionId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.studentRepository.GetByInstitution(institutionId);
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

        [HttpGet("subject/{subjectId:guid}")]
        public async Task<IActionResult> GetStudentsBySubject([FromRoute] Guid subjectId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.studentRepository.GetBySubject(subjectId);
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
