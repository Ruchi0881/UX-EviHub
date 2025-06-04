using AutoMapper;
using EviHub.DTOs;
using EviHub.Models.Entities;
using EviHub.Repositories;

namespace EviHub.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employees = await  _repo.GetAllAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }
        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(emp);
        }
        public async Task<EmployeeDTO> AddEmployeeAsync(CreateEmployeeDTO dto)
        {
            var emp = _mapper.Map<Employee>(dto);
            var created = await _repo.AddEmployeeAsync(emp);
            return _mapper.Map<EmployeeDTO>(created);
        }
        public async Task<EmployeeDTO> UpdateEmployeeAsync(UpdateEmployeeDTO dto)
        {
            var emp = _mapper.Map<Employee>(dto);
            var updated = await _repo.UpdateEmployeeAsync(emp);
            return _mapper.Map<EmployeeDTO>(updated);
        }
        public async Task<bool> DeleteEmployeeAsync(int id) => await _repo.DeleteEmployeeAsync(id);
    }
}
