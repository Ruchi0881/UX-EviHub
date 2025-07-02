
using Evihub.Services;
using EviHub.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Evihub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _service;
        public ProposalController(IProposalService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProposals()=> Ok(await _service.GetAllProposalslAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProposalById(int id)
        {
            var proposal = await _service.GetByIdAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }

            return Ok(proposal);
        }
        [HttpPost]
        public async Task<IActionResult> AddProposal(ProposalDTO dto) 
            {
            dto.EmpId = 1001;
                var created = await _service.AddAsync(dto);
            //var res = GetProposalsByempid(dto.EmpId);
                return Ok(created);
            }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]ProposalDTO dto)
        {

            await _service.UpdateProposalAsync(id, dto);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            if (id == 0) return BadRequest();
            var deleted = await _service.DeleteProposalAsync(id);
            return Ok(deleted);
        }
        [HttpGet("empid")]
        public async Task<IActionResult> GetProposalsByempid(int id)
        {
            var res = await _service.getAllProposalsByEmpId(id);
            return Ok(res);
        }

    }
}
