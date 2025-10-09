using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddUser([FromBody] UserCreateDTO dto)
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        response.Data = await _unitOfWork.UserRepository.Create(dto);
        //        response.StatusCode = 200;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.StatusCode = 400;
        //        response.Message = ex.Message;
        //    }
        //    return BadRequest(response);
        //}

        [HttpPut]
        public async Task<IActionResult> ModifyUser([FromBody] UserUpdateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.UserRepository.Update(dto);
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.UserRepository.Delete(id);
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

        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.UserRepository.GetById(id);
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

        [HttpGet("username/{userName}")]
        public async Task<IActionResult> GetUserByUserName([FromRoute] string userName)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.UserRepository.GetByUserName(userName);
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

        [HttpPost("follow")]
        public async Task<IActionResult> AddFollowing([FromBody] UserFollowDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.UserRepository.Follow(dto);
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
