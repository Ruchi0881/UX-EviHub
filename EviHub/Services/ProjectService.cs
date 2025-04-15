using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> AddProjectAsync(ProjectDTO projectDto)
        {
            var project = new Project
            {
                ProjectName = projectDto.ProjectName
            };

            return await _projectRepository.AddAsync(project);
        }

        public async Task<Project> UpdateProjectAsync(int projectId, ProjectDTO projectDto)
        {
            var project = new Project
            {
                ProjectName = projectDto.ProjectName
            };

            return await _projectRepository.UpdateAsync(projectId, project);
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            return await _projectRepository.DeleteAsync(projectId);
        }
    }
}

