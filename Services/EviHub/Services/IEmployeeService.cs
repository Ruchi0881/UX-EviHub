
using EviHub.DTOs;



namespace Evihub.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
