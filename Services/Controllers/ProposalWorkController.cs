using EviHub.DTOs;
using EviHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposalWorkController : ControllerBase
    {
        private readonly IProposalWorkService _service;
        public ProposalWorkController(IProposalWorkService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("by-proposal/{proposalId}")]
        public async Task<IActionResult> GetByProposalId(int id) => Ok(await _service.GetByProposalIdAsync(id));

        [HttpGet("by-Employee/{Empid}")]
        public async Task<IActionResult> GetByEmpid(int id) => Ok(await _service.GetByEmpIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(ProposalWorkDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProposalWorkDTO dto)
        {
            dto.ProposalWorkId = id;
            await _service.UpdateAsync(dto);
            return Ok(dto);
        }
        [HttpDelete]
        public async Task<IActionResult> delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        

    }
}
