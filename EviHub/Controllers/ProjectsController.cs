using EviHub.Models.DTO_s;
using EviHub.Services;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        //PROJECTS
        [HttpGet("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);    
        }

        // Get project by ID
        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound($"Project with ID {id} not found.");
            return Ok(project);
        }

        // Add a new project
        [HttpPost("projects")]
        public async Task<IActionResult> AddProject([FromBody] ProjectDTO dto)
        {
            var added = await _projectService.AddProjectAsync(dto);
            return Ok(added);
        }

        // Update an existing project
        [HttpPut("projects/{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectDTO dto)
        {
            var updated = await _projectService.UpdateProjectAsync(id, dto);
            if (updated == null)
                return NotFound($"Project with ID {id} not found.");
            return Ok(updated);
        }

        // Delete a project
        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _projectService.DeleteProjectAsync(id);
            if (!deleted)
                return NotFound($"Project with ID {id} not found.");
            return Ok($"Project with ID {id} deleted.");
        }

        //Assign Project to Employee
        [HttpPost("Assign")]
        public async Task<IActionResult> AssignProject (EmployeeProjectDTO dto)
        {
            if (dto == null || dto.EmpId < 0 || dto.ProjectId < 0 || dto.AssignedBy == null)
                return BadRequest("Invalid Data Provided");

            var result = await _projectService.AssignProjectAsync(dto);
            if (result == null)
                return StatusCode(500, "Assignment failed,Please Try Again");
            return Ok("Project assigned Successfully");
        }



        
        }

        



    }
