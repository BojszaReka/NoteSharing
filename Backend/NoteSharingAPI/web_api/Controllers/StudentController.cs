using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.Services.Interfaces;

namespace web_api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManagerService _studentService;
        private readonly IConfiguration _configuration;

        public StudentController(IStudentManagerService studentService, IConfiguration configuration)
        {
            _studentService = studentService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _studentService.GetAllAsync();
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _studentService.GetByIdAsync(id);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("institution/{institutionId:guid}")]
        public async Task<IActionResult> GetStudentsByInstitution([FromRoute] Guid institutionId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _studentService.GetByInstitutionAsync(institutionId);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("subject/{subjectId:guid}")]
        public async Task<IActionResult> GetStudentsBySubject([FromRoute] Guid subjectId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _studentService.GetBySubjectAsync(subjectId);
                response.StatusCode = 200;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
