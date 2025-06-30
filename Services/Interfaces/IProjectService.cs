using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


namespace EviHub.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto);
        Task<ProjectDTO> UpdateProjectAsync(int projectId, ProjectDTO projectDto);
        Task<ProjectDTO?> GetProjectByIdAsync(int ProjectId);
        Task<bool> DeleteProjectAsync(int projectId);
        Task<EmployeeProjectDTO> AssignProjectAsync(EmployeeProjectDTO EmployeeprojectDto);
    }
}
