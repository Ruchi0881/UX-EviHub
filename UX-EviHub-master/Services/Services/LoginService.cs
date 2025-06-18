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

        public LoginService(ILoginRepository loginRepository,EviHubDbContext context, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _context = context;
            _mapper = mapper;
        }
        //public async Task<LoginResponseDTO> AuthenticateAsync (LoginRequestDTO loginDTO)
        //{
        //    using var transaction = await _context.Database.BeginTransactionAsync();

        //    var loginrecord = await _loginRepository.GetByEmailAsync (loginDTO.Email);
        //    if (loginrecord == null) return null;

        //    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password, loginrecord.Password);
        //    if (!isPasswordValid) return null;

        //    var responseDto = _mapper.Map<LoginResponseDTO>(loginrecord);
        //    //responseDto.Token = "dummy-token";

        //    await transaction.CommitAsync();
        //    return responseDto;


        public async Task <bool> AuthenticateAsync(LoginRequestDTO logindto)
        {
            var user = await _loginRepository.AuthenticateAsync(logindto.Email);

            if (user == null)
                return false;

            var record =BCrypt.Net.BCrypt.Verify(logindto.Password, user.Password);
            return record;
        }
        //    var loginRecord = await _context.Logins
        //        .Include(l => l.Employee)
        //        .FirstOrDefaultAsync(l => l.Email == logindto.Email);

            //    if (loginRecord == null || !BCrypt.Net.BCrypt.Verify(logindto.Password, loginRecord.Password))
            //    {
            //        throw new UnauthorizedAccessException("Invalid credentials.");
            //    }

            //    return _mapper.Map<LoginResponseDTO>(loginRecord);
            //}



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

    }


}

