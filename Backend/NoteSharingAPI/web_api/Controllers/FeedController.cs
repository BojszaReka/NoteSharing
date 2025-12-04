using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	[AllowAnonymous]
	[Route("/api/[controller]")]
	[ApiController]
	public class FeedController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public FeedController(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetFeed(Guid userId)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.feedRepository.GetFeedForUser(userId);
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
