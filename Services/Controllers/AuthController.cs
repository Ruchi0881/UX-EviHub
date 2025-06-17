using EviHub.DTOs;
using EviHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
     [ApiController]
     [Route("api/[controller]")]


    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] SignupRequestDTO dto)
        {
            //try
            //{
                var result = await _loginService.SignupAsync(dto);
                return Ok(result);  // 200 OK with SignupResponseDTO
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });  // 400 Bad Request if email exists, etc.
            //}
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            //try
            //{
                var result = await _loginService.AuthenticateAsync(dto);
            if (result == false)
                return Unauthorized("Invalid Username or Password");
            else
                return Ok("Login Successful");// Or ValidateUserAsync()
                //return Ok(result);  // 200 OK with LoginResponseDTO
            //}
            //catch (Exception ex)
            //{
            //    return Unauthorized(new { message = ex.Message });  // 401 Unauthorized if password/email invalid
            //}
        }
    }

}

