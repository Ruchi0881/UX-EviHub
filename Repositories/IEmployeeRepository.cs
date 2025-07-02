using EviHub.Models.Entities;
using Evihub.Data;
using EviHub.DTOs;


namespace Evihub.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<OfficeInfoDTO> GetOfficeInfo(int empid);
    }
}
