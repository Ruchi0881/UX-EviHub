using AutoMapper;
using Evihub.Data;
using EviHub.DTOs;
using EviHub.Repositories;
using BCrypt.Net;
using EviHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Services
{
    public class LoginService :ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly EviHubDbContext _context;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public LoginService(ILoginRepository loginRepository,EviHubDbContext context, IMapper mapper ,JwtService jwtService)
        {
            _loginRepository = loginRepository;
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }
       


        public async Task <bool> AuthenticateAsync(LoginRequestDTO logindto)
        {
            var user = await _loginRepository.AuthenticateAsync(logindto.Email);

            if (user == null)
                return false;

            var record =BCrypt.Net.BCrypt.Verify(logindto.Password, user.Password);
            return record;
        }
        



        public async Task<SignupResponseDTO> SignupAsync(SignupRequestDTO logindto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var employee = _mapper.Map<Employee>(logindto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var login = new Login
            {
                EmpId = employee.EmpId,
                Email = logindto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(logindto.Password)
            };

            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new SignupResponseDTO
            {
                Message = "Signup successful",
                EmpId = employee.EmpId,
                Email = employee.Email
            };
        }

        public async Task<LoginResponseDTO> AuthenticateAndGenerateTokenAsync(LoginRequestDTO dto)
        {
            var login = await _loginRepository.AuthenticateAsync(dto.Email);
            if (login == null) return null;

            var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, login.Password);
            if (!isValid) return null;

            var emp = await _context.Employees.FindAsync(login.EmpId);
            if (emp == null) return null;

            var token = _jwtService.GenerateToken(emp); // still generates JWT from employee

            return new LoginResponseDTO
            {
                Token = token,
                Message = "Login successful",
                EmpId = emp.EmpId,
                Email = emp.Email,
                Role = "Employee" // or derive from emp.IsAdmin etc. later
            };
        }

        //public async Task<string> AuthenticateAndGenerateTokenAsync(LoginRequestDTO dto)
        //{
        //    var login = await _loginRepository.AuthenticateAsync(dto.Email);
        //    if (login == null) return null;

        //    var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, login.Password);
        //    if (!isValid) return null;

        //    var emp = await _context.Employees.FindAsync(login.EmpId);
        //    return _jwtService.GenerateToken(emp); // generates JWT based on employee role
        //}

    }


}

