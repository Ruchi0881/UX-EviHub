using EviHub.DTOs;
using Evihub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Evihub.Controllers
    
{
    //[Authorize(Roles = "Manager,Admin")]
    [ApiController]
    [Route("api/[Controller]")]
    public class CertificationCategoryController :ControllerBase
        
    {
        private readonly ICertificationCategoryService _service;
        public CertificationCategoryController(ICertificationCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories  = await _service.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var cat= await _service.GetByIdAsync(id);
            if(cat == null) return NotFound();
            return Ok(cat);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCertificationCategoryDTO dto){

            var created = await _service.AddAsync(dto);
            return Ok(created);

        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateCertificationCategoryDTO dto)
        {
            var updated = await _service.UpdateAsync(id,dto);
            if(updated == false) return NotFound();
            return Ok(updated);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            var deleted = await _service.DeleteAsync(id);
            return Ok(deleted);
        }
        [HttpGet("{id}/certifications")]
        public async Task<IActionResult> GetCertifications(int id)
        {
            var certification = await _service.GetCertificationsByCategoryId(id);
            return Ok(certification);
        }

    }
}
