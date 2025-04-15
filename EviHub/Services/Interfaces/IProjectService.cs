using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> AddProjectAsync(ProjectDTO projectDto);
        Task<Project> UpdateProjectAsync(int projectId, ProjectDTO projectDto);
        Task<bool> DeleteProjectAsync(int projectId);
    }
}
