
using Evihub.Repositories;
using Evihub.Services;
using EviHub.DTOs;
using EviHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Evihub.Controllers
{
    //[Authorize(Roles = "Employee,Manager,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeService service, IEmployeeRepository repo)
        {
            _service = service;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _service.GetByIdAsync(id);
            if(emp == null) { return NotFound(); }
            return Ok(emp);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDTO dto)
        {
            var created = await _service.AddEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EmpId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id,EmployeeDTO dto)
        {
            
            var updated = await _service.UpdateEmployeeAsync(dto);
            return Ok(updated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _service.DeleteEmployeeAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
        [HttpGet("OfficeInfo")]
        public async Task<ActionResult> GetOfficeinfo(int empid)
        {
            var employee =  await _repo.GetOfficeInfo(empid);
            if(employee == null) { return NotFound(); };
            return Ok(employee);
        }
    }
}
