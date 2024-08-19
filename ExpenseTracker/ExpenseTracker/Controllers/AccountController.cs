using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var result = await _applicationUserService.RegisterAsync(model);
            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            // Validate user credentials
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized("Invalid login attempt");
            }

            var token = await _applicationUserService.GenerateJwtTokenAsync(user);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _applicationUserService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _applicationUserService.GetUserByIdAsync(userId);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with ID {userId} not found");
        }

        [Authorize]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, ApplicationUser user)
        {
            if (userId != user.Id)
            {
                return BadRequest("User ID mismatch");
            }

            await _applicationUserService.UpdateUserAsync(user);
            return Ok($"User with ID {userId} updated successfully");
        }

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var deletionResult = await _applicationUserService.DeleteUserAsync(userId);

            if (deletionResult)
            {
                return Ok($"User with ID {userId} deleted successfully");
            }
            else
            {
                return NotFound($"User with ID {userId} not found");
            }
        }
    }
}
