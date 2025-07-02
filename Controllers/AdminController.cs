using EviHub.DTOs;
using Evihub.Services;
using Microsoft.AspNetCore.Mvc;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EviHub.Controllers
{
    //[Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GENDERS
        [HttpGet("genders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var gender = await _adminService.GetAllGendersAsync();
            return Ok(gender);
        }

        [HttpPost("genders")]
        public async Task<IActionResult> AddGender([FromBody] GenderDTO dto) 
        {
            var added = await _adminService.AddGenderAsync(dto);
            return Ok($"Gender added successfully");
        }

        [HttpPut("genders/{id}")]
        public async Task<IActionResult> UpdateGender(int id, GenderDTO dto)
        {
            var updated = await _adminService.UpdateGenderAsync(id, dto);
            if (updated == null) return NotFound();
             return Ok(updated);    
        }

        [HttpGet("genders/{id}")]
        public  async Task<IActionResult> GetGenderById (int id)
        {
            var result = await _adminService.GetGenderByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("genders/{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var success = await _adminService.DeleteGenderAsync(id);
            if(!success) return NotFound();
            return Ok($"Gender wih ID {id} Deleted Successfully");
        }

        //MANAGERS


        // GET all managers
        [HttpGet("managers")]
        public async Task<IActionResult> GetAllManagers()
        {
            var result = await _adminService.GetAllManagersAsync();
            return Ok(result);
        }

        // GET manager by ID
        [HttpGet("managers/{id}")]
        public async Task<IActionResult> GetManagerById(int id)
        {
            var result = await _adminService.GetManagerByIdAsync(id);
            if (result == null)
                return NotFound(new { message = $"Manager with ID {id} not found." });

            return Ok(result);
        }

        // POST new manager
        [HttpPost("managers")]
        public async Task<IActionResult> AddManager(ManagerDTO dto)
        {
            var result = await _adminService.AddManagerAsync(dto);
            return Ok(result);
        }

        // PUT (update) manager
        [HttpPut("managers/{id}")]
        public async Task<IActionResult> UpdateManager(int id, ManagerDTO dto)
        {
            var result = await _adminService.UpdateManagerAsync(id, dto);
            if (result == null)
                return NotFound(new { message = $"Manager with ID {id} not found." });

            return Ok(result);
        }

        // DELETE manager
        [HttpDelete("managers/{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var success = await _adminService.DeleteManagerAsync(id);
            if (!success)
                return NotFound(new { message = $"Manager with ID {id} not found." });

            return Ok(new { message = $"Manager with ID {id} deleted successfully." });
        }






        //PROJECTS



        [HttpGet("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _adminService.GetAllProjectsAsync();
            return Ok(projects);
        }

        // Get project by ID
        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _adminService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound($"Project with ID {id} not found.");
            return Ok(project);
        }

        // Add a new project
        [HttpPost("projects")]
        public async Task<IActionResult> AddProject(ProjectDTO dto)
        {
            var created = await _adminService.AddProjectAsync(dto);
            return Ok(created);
        }

        // Update an existing project
        [HttpPut("projects/{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectDTO dto)
        {
            var updated = await _adminService.UpdateProjectAsync(id, dto);
            if (updated == null)
                return NotFound($"Project with ID {id} not found.");
            return Ok(updated);
        }

        // Delete a project
        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _adminService.DeleteProjectAsync(id);
            if (!deleted)
                return NotFound($"Project with ID {id} not found.");
            return Ok($"Project with ID {id} deleted.");
        }



        



        //CERTIFICATIONS

        //[HttpGet("certifications")]
        //public async Task<IActionResult> GetAllCertifications()
        //{
        //    var result = await _adminService.GetAllCertificationsAsync();
        //    return Ok(result);
        //}

        //[HttpGet("certifications/{id}")]
        //public async Task<IActionResult> GetCertificationById(int id)
        //{
        //    var result = await _adminService.GetCertificationByIdAsync(id);
        //    if (result == null) return NotFound();
        //    return Ok(result);
        //}

        //[HttpPost("certifications")]
        //public async Task<IActionResult> AddCertification(CertificationDTO dto)
        //{
        //    var result = await _adminService.AddCertificationAsync(dto);
        //    return Ok($"Certification Added Successfully");
        //}

        //[HttpPut("certifications/{id}")]
        //public async Task<IActionResult> UpdateCertification(int id, CertificationDTO dto)
        //{
        //    var result = await _adminService.UpdateCertificationAsync(id, dto);
        //    return Ok($"Certification with ID {id}updated successfully");
        //}

        //[HttpDelete("certifications/{id}")]
        //public async Task<IActionResult> DeleteCertification(int id)
        //{
        //    var result = await _adminService.DeleteCertificationAsync(id);
        //    return Ok($"Certification wih ID {id} Deleted Successfully");
        //}



        //DESIGNATIONS

        [HttpGet("designations")]
        public async Task<IActionResult> GetAllDesignations()
        {
            var result = await _adminService.GetAllDesignationsAsync();
            return Ok(result);
        }

        [HttpGet("designations/{id}")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var result = await _adminService.GetDesignationByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("designations")]
        public async Task<IActionResult> AddDesignation(DesignationDTO dto)
        {
            var result = await _adminService.AddDesignationAsync(dto);
            return Ok($"Designation added successfully");
        }

        [HttpPut("designations/{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, DesignationDTO dto)
        {
            var result = await _adminService.UpdateDesignationAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("designations/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var result = await _adminService.DeleteDesignationAsync(id);
            return Ok($"Designation wih ID {id} Deleted Successfully");
        }

        //SKILLS

        // GET: api/Skill(Get All Skills)
        [HttpGet("GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _adminService.GetAllSkillsAsync();
            return Ok(result);
        }

        [HttpGet("skills/{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _adminService.GetSkillByIdAsync(id);
            if (skill == null)
            return NotFound($"Skill with ID {id} not found.");
            return Ok(skill);
        }

        // POST: api/Skill(Add new skill)
        [HttpPost("Add new skill")]
        public async Task<IActionResult> AddSkill( SkillDTO dto)
        {
            var result = await _adminService.AddSkillAsync(dto);
            return Ok($"Skill added successfully");
        }

        //// PUT: api/Skill/{id} (Update Skill)
        //[HttpPut("skills/{id}")]
        //public async Task<IActionResult> UpdateSkill(int id, SkillDTO dto)
        //{
        //    var result = await _adminService.UpdateSkillAsync(id, dto);
        //    return Ok($"Skill with ID {id} Updated successfully");
        //}

        // DELETE: api/Skill/{id}(Delete Skills)
        [HttpDelete("skills/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _adminService.DeleteSkillAsync(id);
            return Ok($"Skill wih ID {id} Deleted Successfully");
        }

    }
}












