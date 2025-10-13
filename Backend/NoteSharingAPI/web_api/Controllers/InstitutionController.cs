using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	/// <summary>
	/// Controller for managing institution-related operations such as create, update, delete, and retrieval.
	/// </summary>
	[AllowAnonymous]
	[Route("/api/[controller]")]
	[ApiController]
	public class InstitutionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="InstitutionController"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work that provides access to the institution repository.</param>
		public InstitutionController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

		/// <summary>
		/// Creates a new institution record.
		/// </summary>
		/// <param name="dto">The data transfer object containing details of the institution to be created.</param>
		/// <returns>
		/// A task that represents the asynchronous operation.  
		/// The task result contains an <see cref="IActionResult"/> with the created institution details on success.
		/// </returns>
		/// <response code="200">Returns the created institution details.</response>
		/// <response code="400">Returned when validation fails or an exception occurs.</response>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] InstitutionCreateDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.institutionRepository.Create(dto);
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

		/// <summary>
		/// Updates an existing institution record.
		/// </summary>
		/// <param name="dto">The institution data transfer object containing updated values.</param>
		/// <returns>
		/// A task that represents the asynchronous operation.  
		/// The task result contains an <see cref="IActionResult"/> with the updated institution details on success.
		/// </returns>
		/// <response code="200">Returns the updated institution details.</response>
		/// <response code="400">Returned when the institution does not exist or an exception occurs.</response>
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] InstitutionViewDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.institutionRepository.Update(dto);
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

		/// <summary>
		/// Deletes (sets inactive) an institution record by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the institution to delete.</param>
		/// <returns>
		/// A task that represents the asynchronous operation.  
		/// The task result contains an <see cref="IActionResult"/> indicating whether the deletion was successful.
		/// </returns>
		/// <response code="200">Indicates the institution was successfully deleted (set inactive).</response>
		/// <response code="400">Returned when the institution is not found or an exception occurs.</response>
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.institutionRepository.Delete(id);
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

		/// <summary>
		/// Retrieves a specific institution by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the institution to retrieve.</param>
		/// <returns>
		/// A task that represents the asynchronous operation.  
		/// The task result contains an <see cref="IActionResult"/> with the requested institution details on success.
		/// </returns>
		/// <response code="200">Returns the requested institution details.</response>
		/// <response code="400">Returned when the institution is not found or an exception occurs.</response>
		[HttpGet("{id:guid}")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.institutionRepository.GetById(id);
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

		/// <summary>
		/// Retrieves all active institutions.
		/// </summary>
		/// <returns>
		/// A task that represents the asynchronous operation.  
		/// The task result contains an <see cref="IActionResult"/> with a list of all active institutions.
		/// </returns>
		/// <response code="200">Returns a list of all active institutions.</response>
		/// <response code="400">Returned when no institutions are found or an exception occurs.</response>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.institutionRepository.GetAll();
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
