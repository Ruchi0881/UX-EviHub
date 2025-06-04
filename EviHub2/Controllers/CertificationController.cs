using AutoMapper;
using EviHub2.DTOs;
using EviHub2.Models.Entities;
using EviHub2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EviHub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationController : ControllerBase
    {

        private readonly ICertificationService _service;
        private readonly IMapper _mapper;
        public CertificationController(ICertificationService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCertifications()
        {
            var certificate = await _service.GetAllCertificationsAsync();
            return Ok(certificate);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificationById(int id)
        {
            var certificate = await  _service.GetCertificationById(id);
            if (certificate == null)
            {
                return BadRequest("Certification Does not exist");
            }
            return Ok(certificate);
        }
        [HttpPost]
        public async Task<IActionResult> AddCertificate([FromBody] CertificationDTO dto)
        {
            var certification = _mapper.Map<Certification>(dto);
            await _service.AddCertificationsAsync(certification);
            return Ok(certification);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertification(int id,[FromBody]CertificationDTO dto){
            if (id != dto.CertificationId) { BadRequest("Cerification Id Mismatch"); }
            var existing = await _service.GetCertificationById(id);
            if (existing == null)
            {
                return NotFound("certification Not Found");
            }
                _mapper.Map(dto, existing);
             await _service.UpdateCertificationAsync(existing);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            try
            {
                await _service.DeleteCertificationsAsync(id);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        

    }
}
