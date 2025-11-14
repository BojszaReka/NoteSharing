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
    public class CollectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public CollectionsController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("createCollection")]
        public async Task<IActionResult> CreateCollection([FromBody] CollectionCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.collectionRepository.Create(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        [HttpPut("modifyCollection")]
        public async Task<IActionResult> ModifyCollection([FromBody] CollectionViewDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.collectionRepository.Update(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        [HttpPost("{collectionId:guid}/addNote/{noteId:guid}")]
        public async Task<IActionResult> AddNote(Guid collectionId, Guid noteId)
        {
            var response = new ApiResponse();
            try
            {
                var dto = new CollectionNoteDTO { CollectionID = collectionId, NoteID = noteId };
                response.Data = await _unitOfWork.collectionRepository.AddNote(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        [HttpDelete("{collectionId:guid}/removeNote/{noteId:guid}")]
        public async Task<IActionResult> RemoveNote(Guid collectionId, Guid noteId)
        {
            var response = new ApiResponse();
            try
            {
                var dto = new CollectionNoteDTO { CollectionID = collectionId, NoteID = noteId };
                response.Data = await _unitOfWork.collectionRepository.RemoveNote(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }


        [HttpPost("{collectionId:guid}/setPrivate/{isPrivate:bool}")]
        public async Task<IActionResult> SetPrivate(Guid collectionId, bool isPrivate)
        {
            var response = new ApiResponse();
            try
            {
                var dto = new CollectionViewDTO { ID = collectionId, Private = isPrivate };
                response.Data = await _unitOfWork.collectionRepository.Update(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        [HttpGet("getCollection/{id:guid}")]
        public async Task<IActionResult> GetCollection(Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.collectionRepository.Get(id);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }


        // getCollections (by userId)
        [HttpGet("getCollections/{userId:guid}")]
        public async Task<IActionResult> GetCollections(Guid userId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.collectionRepository.GetByUser(userId);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }
    }
}
