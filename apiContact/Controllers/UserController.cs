using apiContact.Models.Dtos;
using apiContact.Models.Entity;
using apiContact.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiContact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<ApiResponse<UserProfile>>> GetUserProfile()
        {
            try
            {
                // In a real app, you'd get the user ID from authentication
                var userId = 1; // Mock user ID
                var profile = await _userService.GetUserProfileAsync(userId);

                if (profile == null)
                {
                    return NotFound(new ApiResponse<UserProfile>
                    {
                        Data = null,
                        Success = false,
                        Message = "User profile not found"
                    });
                }

                return Ok(new ApiResponse<UserProfile>
                {
                    Data = profile,
                    Success = true,
                    Message = "Profile retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user profile");

                return StatusCode(500, new ApiResponse<UserProfile>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occurred while retrieving the profile"
                });
            }
        }
    }
}
