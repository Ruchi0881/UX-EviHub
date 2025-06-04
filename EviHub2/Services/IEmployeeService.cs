using EviHub2.DTOs;
using EviHub2.Models.Entities;

namespace EviHub2.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(CreateEmployeeDTO employee);
        Task<EmployeeDTO> UpdateEmployeeAsync(UpdateEmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
