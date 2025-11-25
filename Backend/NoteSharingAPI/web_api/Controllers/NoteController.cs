using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using class_library.DTO;
using class_library.Models;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public NoteController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        // CreateNote
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Add(dto);
                response.StatusCode = 200; 
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message; 
                
            }
			return BadRequest(response);
		}

        // GetNote -> by id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetNote([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Get(id);
                response.StatusCode = 200; 
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message; 
            }
			return BadRequest(response);
		}

        // GetAllNotes (only the public ones)
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.GetAll();
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message;  
            }
			return BadRequest(response);
		}

        // ModifyNote
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NoteUpdateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Update(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message; 
            }
			return BadRequest(response);
		}

        // deleteNote
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Delete(id);
                response.StatusCode = 200; 
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message; 
            }
			return BadRequest(response);
		}

        // addReview -> a projektedben ennek megfelelő DTO a NoteRatingCreateDTO
        [HttpPost("review")]
        public async Task<IActionResult> AddReview([FromBody] NoteRatingCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.AddReview(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { 
                response.StatusCode = 400; 
                response.Message = ex.Message; 
            }
			return BadRequest(response);
		}

		[HttpPost("like")]
		public async Task<IActionResult> Like([FromBody] NoteLikeDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.noteRepository.Like(dto);
				response.StatusCode = 200; response.Message = "Success";
				return Ok(response);
			}
			catch (Exception ex)
			{
				response.StatusCode = 400;
				response.Message = ex.Message;
			}
			return BadRequest(response);
		}

		[HttpDelete("like")]
		public async Task<IActionResult> Dislike([FromBody] NoteLikeDTO dto)
		{
			var response = new ApiResponse();
			try
			{
				response.Data = await _unitOfWork.noteRepository.Dislike(dto);
				response.StatusCode = 200; response.Message = "Success";
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
