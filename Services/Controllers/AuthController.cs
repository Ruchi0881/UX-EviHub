using Evihub.Data;
using EviHub.DTOs;
using EviHub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Controllers
{
     [ApiController]
     [Route("api/[controller]")]


    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly EviHubDbContext _context;

        public AuthController(ILoginService loginService,EviHubDbContext context)
        {
            _loginService = loginService;
            _context = context;
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
            
            var y = _context.Employees.FirstOrDefault(x => x.Email == dto.Email);
            
            //try
            //{
                var result = await _loginService.AuthenticateAsync(dto);
            if (result == false)
                return Unauthorized("Invalid Username or Password");
            else
                return Ok(y.EmpId);// Or ValidateUserAsync()
                //return Ok(result);  // 200 OK with LoginResponseDTO
            //}
            //catch (Exception ex)
            //{
            //    return Unauthorized(new { message = ex.Message });  // 401 Unauthorized if password/email invalid
            //}
        }
    }

}

