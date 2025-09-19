using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection.Metadata.Ecma335;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	public class ExampleController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public ExampleController(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		//[HttpGet("api/example")]
		//public async Task<IActionResult> GetExampleData(ParameterType parameter)
		//{
		//	ApiResponseFormat response = new ApiResponse();
		//	try
		//	{
		//		response.Data = await _unitOfWork.ExampleRepository.MethodNameAsync(parameter);
		//		response.StatusCode = 200;
		//		reponse.Message = "Success";
		//		return Ok(response);
		//	}
		//	catch (Exception ex)
		//	{
		//		response.StatusCode = 400;
		//		response.Message = ex.Message;
		//	}
		//	return BadRequest(response);
		//}
	}
}
