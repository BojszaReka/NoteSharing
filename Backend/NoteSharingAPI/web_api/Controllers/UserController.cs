using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(IUnitOfWork uow) : Controller
    {
        private readonly IUnitOfWork _uow = uow;

        // create
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.Create(dto);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.StatusCode = 400; response.Message = e.Message;
                return BadRequest(response);
            }
        }

        // update
        [HttpPut]
        public async Task<IActionResult> ModifyUser([FromBody] UserUpdateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.Update(dto);
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }

        // delete
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.Delete(id);
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }

        // get by id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.GetById(id);
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }

        // get by username
        [HttpGet("by-username/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.GetByUserName(userName);
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }

        // get all
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.GetAll();
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }

        // follow
        [HttpPost("follow")]
        public async Task<IActionResult> Follow([FromBody] UserFollowDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _uow.UserRepository.Follow(dto);
                return Ok(response);
            }
            catch (Exception e) { response.StatusCode = 400; response.Message = e.Message; }
            return BadRequest(response);
        }
    }
}
