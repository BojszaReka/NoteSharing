using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	/// <summary>
	/// Controller responsible for managing user-related operations such as creation, modification, retrieval, deletion, and user relationships (following).
	/// <para>
	/// Endpoints provided:
	/// <list type="bullet">
	///   <item><description><b>PUT /api/user</b>: Modifies user information.</description></item>
	///   <item><description><b>DELETE /api/user/{id}</b>: Deletes a user by their unique identifier.</description></item>
	///   <item><description><b>GET /api/user/id/{id}</b>: Retrieves a user by their unique identifier.</description></item>
	///   <item><description><b>GET /api/user/username/{userName}</b>: Retrieves a user by their username.</description></item>
	///   <item><description><b>POST /api/user/follow</b>: Adds a following relationship between two users.</description></item>
	/// </list>
	/// </para>
	/// <remarks>
	/// All endpoints are accessible anonymously.
	/// </remarks>
	/// </summary>
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
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

        /// <summary>
        /// This endpoint is for adding additional user information or modifying the existing one.
        /// Only the fields in <see cref="UserUpdateDTO"/> that are provided (not null) will be updated; all others will remain unchanged.
        /// The <c>ID</c> field is required to identify the user to update.
        /// </summary>
        /// <param name="dto">The user update data transfer object. Except for <c>ID</c>, all properties should be null unless they are to be changed.</param>
        /// <returns>ApiResponse containing the updated user or error details.</returns>
        [HttpPut]
        public async Task<IActionResult> ModifyUser([FromBody] UserUpdateDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.userRepository.Update(dto);
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
        /// Deletes a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>ApiResponse indicating success or failure.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.userRepository.Delete(id);
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
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>ApiResponse containing the user or error details.</returns>
        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.userRepository.GetById(id);
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
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>ApiResponse containing the user or error details.</returns>
        [HttpGet("username/{userName}")]
        public async Task<IActionResult> GetUserByUserName([FromRoute] string userName)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.userRepository.GetByUserName(userName);
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
        /// Adds a one sided following relationship between two users.
        /// </summary>
        /// <param name="dto">
        /// The user follow data transfer object.
        /// <br/>
        /// <b>Properties of <see cref="UserFollowDTO"/>:</b>
        /// <list type="bullet">
        /// <item>
        /// <description><c>FollowerUserID</c> (<see cref="Guid"/>): The unique identifier of the user who is following.</description>
        /// </item>
        /// <item>
        /// <description><c>FollowingUserID</c> (<see cref="Guid"/>): The unique identifier of the user being followed.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>ApiResponse indicating success or failure.</returns>
        [HttpPost("follow")]
        public async Task<IActionResult> AddFollowing([FromBody] UserFollowDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _unitOfWork.userRepository.Follow(dto);
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
