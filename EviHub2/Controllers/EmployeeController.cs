using EviHub.DTOs;
using EviHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
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
        public async Task<IActionResult> AddEmployeeAsync(CreateEmployeeDTO dto)
        {
            var created = await _service.AddEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EmpId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id,UpdateEmployeeDTO dto)
        {
            if (id != dto.EmployeeId) return BadRequest();
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
    }
}
