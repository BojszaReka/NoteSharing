using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public SearchController(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		[HttpGet("notes")]
		public async Task<IActionResult> SearchNotes([FromBody] NoteSearchDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.searchRepository.SearchNotes(dto);
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

		[HttpGet("users")]
		public async Task<IActionResult> SearchUsers([FromBody] UserSearchDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.searchRepository.SearchUsers(dto);
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

		[HttpGet("subjects")]
		public async Task<IActionResult> SearchSubjects([FromBody] SubjectSearchDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.searchRepository.SearchSubjects(dto);
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
