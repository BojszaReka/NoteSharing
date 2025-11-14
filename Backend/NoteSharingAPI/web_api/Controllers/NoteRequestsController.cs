using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;
using class_library.Enums; 


namespace web_api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteRequestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public NoteRequestController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        // createRequest
        [HttpPost("createRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] NoteRequestCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.Create(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // modifyRequest - Fix: Create update method that accepts NoteRequestViewDTO
        [HttpPut("modifyRequest")]
        public async Task<IActionResult> ModifyRequest([FromBody] NoteRequestViewDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                // Convert NoteRequestViewDTO to NoteRequestCreateDTO for the Create method
                var createDto = new NoteRequestCreateDTO
                {
                    CreatorUserID = dto.CreatorUserID,
                    SubjectID = dto.SubjectID,
                    Topic = dto.Topic,
                    Description = dto.Description
                };
                response.Data = await _unitOfWork.noteRequestRepository.Create(createDto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // changeRequestStatus
        [HttpPost("changeRequestStatus/{requestId:guid}/{newStatus}")]
        public async Task<IActionResult> ChangeRequestStatus(Guid requestId, ERequestStatus newStatus)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.UpdateStatus(requestId, newStatus);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }


        // getRequest -> by userId (request the user made)
        [HttpGet("getRequest/{userId:guid}")]
        public async Task<IActionResult> GetRequestByUser([FromRoute] Guid userId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.GetByCreator(userId);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // getRelevantRequest -> by userId (requests user may answer)
        [HttpGet("getRelevantRequest/{userId:guid}")]
        public async Task<IActionResult> GetRelevantRequestByUser([FromRoute] Guid userId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.GetRelevantRequest(userId);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // addAnswer
        [HttpPost("addAnswer")]
        public async Task<IActionResult> AddAnswer([FromBody] NoteRequestAnswerCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.AddAnswer(dto);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // viewAnswers -> by noteid
        [HttpGet("viewAnswers/byNote/{noteId:guid}")]
        public async Task<IActionResult> ViewAnswersByNote([FromRoute] Guid noteId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.ViewAnswersByNote(noteId);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // viewAnswers -> by userid
        [HttpGet("viewAnswers/byUser/{userId:guid}")]
        public async Task<IActionResult> ViewAnswersByUser([FromRoute] Guid userId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.ViewAnswersByUser(userId);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }

        // changeAnswerStatus
        [HttpPost("changeAnswerStatus/{answerId:guid}/{newStatus}")]
        public async Task<IActionResult> ChangeAnswerStatus(Guid answerId, EAnswerStatus newStatus)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.noteRequestRepository.UpdateAnswerStatus(answerId, newStatus);
                response.StatusCode = 200; response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex) { response.StatusCode = 400; response.Message = ex.Message; return BadRequest(response); }
        }
    }
}
