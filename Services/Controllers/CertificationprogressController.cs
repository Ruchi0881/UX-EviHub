using EviHub.DTOs;

using Evihub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Evihub.Controllers
{
    //[Authorize(Roles = "Employee")]
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationprogressController : ControllerBase
    {
        private readonly ICertificationprogressService _service;
        public CertificationprogressController (ICertificationprogressService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var res = await _service.GetAsync(id);
            return res == null ? NotFound() : Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCertificationprogressDTO dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = created.CertificationProgressId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id,UpdateCertificationprogressDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return Ok(deleted);
        }
        [HttpGet("employee/{empId}")]
        public async Task<IActionResult> getByEmployeeid(int empId)
        {
            var res = await _service.GetByEmployeeId(empId);
            return Ok(res);
        }
        [HttpGet("certifcation/{certificationId}")]
        public async Task<IActionResult> GetbyCertificationId(int certificationId)
        {
            var res = await _service.GetByCertificationId(certificationId);
            return Ok(res);
        }



    }
}
