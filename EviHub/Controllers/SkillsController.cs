using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {


        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        // GET: api/Skill(Get All Skills)
        [HttpGet("GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _service.GetAllSkillsAsync();
            return Ok(skills);
        }

        // POST: api/Skill(Add new skill)
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillDTO dto)
        {
            var createdSkill = await _service.AddSkillAsync(dto);
            return CreatedAtAction(nameof(GetAllSkills), new { id = createdSkill.SkillId }, createdSkill);
        }

        // PUT: api/Skill/{id} (Update Skill)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] SkillDTO dto)
        {
            var updatedSkill = await _service.UpdateSkillAsync(id,dto);
            if (updatedSkill == null)
                return NotFound();

            return Ok(updatedSkill);
        }

        // DELETE: api/Skill/{id}(Delete Skills)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _service.DeleteSkillAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
