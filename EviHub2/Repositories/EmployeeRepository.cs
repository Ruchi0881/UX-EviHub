using EviHub2.Data;
using EviHub2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EviHub2.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EviHubDbContext _context;
        public EmployeeRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        } 
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var emp = await  _context.Employees.FindAsync(id);
            if(emp == null) return false;
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
