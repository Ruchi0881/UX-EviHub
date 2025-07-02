using EviHub.DTOs;
using EviHub.Services;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    //[Authorize(Roles = "Employee")]
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {


        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        //GET
        [HttpGet("GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _service.GetAllSkillsAsync();
            return Ok(skills);
        }

        // GET: api/Skill(Get All Skills)
        [HttpGet("employee/{empId}")]
        public async Task<IActionResult> GetSkillsByEmpId(int empId)
        {
            var skills = await _service.GetSkillsByEmpIdAsync(empId);
            return Ok(skills);
        }

        // POST: api/Skill(Add new skill)
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillDTO dto)
        {
            var createdSkill = await _service.AddSkillAsync(dto);
            return Ok(createdSkill);
        }

        // PUT: api/Skill/{id} (Update Skill)
        [HttpPut("employee")]
        public async Task<IActionResult> UpdateEmployeeSkills([FromBody] UpdateEmployeeSkillsDTO dto)
        {
            try
            {
                await _service.UpdateEmployeeSkillsAsync(dto);
                return Ok("Skills updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET :api/Skill/{id} (GetSkillById)
        [HttpGet("skills/{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _service.GetSkillByIdAsync(id);
            if (skill == null)
                return NotFound($"Skill with ID {id} not found.");
            return Ok(skill);
        }

        //POST :api/Skill/{id} (AddnewSkills)
        [HttpPost("employee-skills")]
        public async Task<IActionResult> AddEmployeeSkills([FromBody] AddEmployeeSkillsDTO skillDto)
        {
            var result = await _service.AddEmployeeSkillsAsync(skillDto);
            return Ok(result);
        }

        // DELETE: api/Skill/{id}(Delete Skills)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _service.DeleteSkillAsync(id);
            if (!result)
                return NotFound();

            return Ok("Skills Deleted Successfully");
        }
        //DELETE :api/Skill/{EmpId}{SkillId}
        [HttpDelete("employee-skills/{empId}/{skillId}")]
        public async Task<IActionResult> DeleteEmployeeSkill(int empId, int skillId)
        {
            await _service.DeleteSkillForEmployeeAsync(empId, skillId);
            return Ok();
        }
        //DELETE :api/skills/bulk delete
        [HttpDelete("employee-skills/{empId}")]
        public async Task<IActionResult> DeleteMultipleSkillEmployeeAsync(int empId, [FromBody] List<int> skillId)
        {
            await _service.DeleteMultipleSkillForEmployeeAsync(new AddEmployeeSkillsDTO
            {
                EmpId = empId,
                SkillId = skillId
            });

            return Ok();
        }

    }
}
