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
        [HttpPost("createNote")]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Create(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // GetNote -> by id
        [HttpGet("getNote/{id:guid}")]
        public async Task<IActionResult> GetNote([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Get(id);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // GetAllNotes (only the public ones)
        [HttpGet("getAllNotes")]
        public async Task<IActionResult> GetAllNotes()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Search(null, null, null);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // ModifyNote
        [HttpPut("modifyNote")]
        public async Task<IActionResult> ModifyNote([FromBody] NoteUpdateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Update(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // deleteNote
        [HttpDelete("deleteNote/{id:guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.SoftDelete(id);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // addReview -> a projektedben ennek megfelelő DTO a NoteRatingCreateDTO
        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview([FromBody] NoteRatingCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRepository.Rate(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }
    }
}
