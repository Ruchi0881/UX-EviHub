using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Services;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMasterDataController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public AdminMasterDataController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        // GENDERS
        [HttpGet("genders")]
        public async Task<IActionResult> GetGenders()
        {
            return Ok(await _genderService.GetAllGendersAsync());
        }

        [HttpPost("genders")]
        public async Task<IActionResult> AddGender([FromBody] GenderDTO dto)
        {
            var result = await _genderService.AddGenderAsync(dto);
            return CreatedAtAction(nameof(GetGenders), new { id = result.GenderId }, result);
        }

        [HttpPut("genders/{id}")]
        public async Task<IActionResult> UpdateGender(int Genderid, [FromBody] GenderDTO dto)
        {
            var result = await _genderService.UpdateGenderAsync(Genderid, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("genders/{id}")]
        public async Task<IActionResult> DeleteGender(int Genderid)
        {
            var success = await _genderService.DeleteGenderAsync(Genderid);
            return success ? NoContent() : NotFound();
        }

        //MANAGERS
        private readonly IManagerService _managerService;

        public AdminMasterDataController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("manager")]
        public async Task<IActionResult> GetManagers()
        {
            var managers = await _managerService.GetAllManagersAsync();
            return Ok(managers);
        }

        [HttpPost("manager")]
        public async Task<IActionResult> AddManager([FromBody] ManagerDTO dto)
        {
            var result = await _managerService.AddManagerAsync(dto);
            return Ok(result);
        }

        [HttpPut("manager/{id}")]
        public async Task<IActionResult> UpdateManager(int id, [FromBody] ManagerDTO dto)
        {
            var updated = await _managerService.UpdateManagerAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("manager/{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var deleted = await _managerService.DeleteManagerAsync(id);
            if (!deleted) return NotFound();
            return Ok(new { message = "Manager deleted successfully" });
        }
        //PROJECTS
        private readonly IProjectService _projectService;

        public AdminMasterDataController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet("project")]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjectsAsync());
        }

        [HttpPost("project")]
        public async Task<IActionResult> AddProject([FromBody] ProjectDTO project)
        {
            return Ok(await _projectService.AddProjectAsync(project));
        }

        [HttpPut("project/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDTO dto)
        {
            var result = await _projectService.UpdateProjectAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            return result ? Ok() : NotFound();
        }
        //CERTIFICATIONS
        private readonly ICertificationService _certificationService;

        public AdminMasterDataController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }
        [HttpGet("certification")]
        public async Task<IActionResult> GetAllCertifications()
        {
            var result = await _certificationService.GetAllCertificationsAsync();
            return Ok(result);
        }

        [HttpPost("certifications")]
        public async Task<IActionResult> AddCertification(CertificationDTO dto)
        {
            var result = await _certificationService.AddCertificationAsync(dto);
            return Ok(result);
        }

        [HttpPut("certifications/{id}")]
        public async Task<IActionResult> UpdateCertification(int id, CertificationDTO dto)
        {
            var result = await _certificationService.UpdateCertificationAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("certifications/{id}")]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            var result = await _certificationService.DeleteCertificationAsync(id);
            return Ok(result);
        }

        //DESIGNATIONS
        private readonly IDesignationService _designationService;

        public AdminMasterDataController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        [HttpGet("designations")]
        public async Task<IActionResult> GetAllDesignations()
        {
            var result = await _designationService.GetAllDesignationsAsync();
            return Ok(result);
        }
        [HttpPost("designations")]
        public async Task<IActionResult> AddDesignation(DesignationDTO dto)
        {
            var result = await _designationService.AddDesignationAsync(dto);
            return Ok(result);
        }

        [HttpPut("designations/{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, DesignationDTO dto)
        {
            var result = await _designationService.UpdateDesignationAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("designations/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var result = await _designationService.DeleteDesignationAsync(id);
            return Ok(result);
        }
        //SKILLS
        private readonly ISkillService _skillService;

        public AdminMasterDataController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/Skill(Get All Skills)
        [HttpGet("designations/GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _skillService.GetAllSkillsAsync();
            return Ok(result);
        }

        // POST: api/Skill(Add new skill)
        [HttpPost("designations/Add new skill")]
        public async Task<IActionResult> AddSkill([FromBody] SkillDTO dto)
        {
            var result = await _skillService.AddSkillAsync(dto);
            return CreatedAtAction(nameof(GetAllSkills), new { id = result.SkillId }, result);
        }

        // PUT: api/Skill/{id} (Update Skill)
        [HttpPut("designations/{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] SkillDTO dto)
        {
            var result = await _skillService.UpdateSkillAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        // DELETE: api/Skill/{id}(Delete Skills)
        [HttpDelete("designations/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

    }
}







        

          


