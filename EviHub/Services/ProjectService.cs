using AutoMapper;
using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;

using EviHub.Models.Entities;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EviHub.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var proj = await _projectRepository.GetAllAsync();
            return _mapper.Map<List<ProjectDTO>>(proj);
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto)
        {
            var proj = _mapper.Map<Project>(projectDto);
            var addedproj = await _projectRepository.AddAsync  (proj);
            return _mapper.Map<ProjectDTO>(addedproj);
        }

        public async Task<ProjectDTO> UpdateProjectAsync(int id, ProjectDTO projectDto)
        {
            var existingproj = await _projectRepository.GetByIdAsync(id);
            if (existingproj == null) return null;

            existingproj.ProjectName = projectDto.ProjectName;
            existingproj.ProjectDescription = projectDto.ProjectDescription;
            existingproj.IsActive = projectDto.IsActive;

            var updated = await _projectRepository.UpdateAsync(id, existingproj);
            return _mapper.Map<ProjectDTO>(updated);
        }
        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var proj = await _projectRepository.GetByIdAsync(id);
            return proj == null ? null : _mapper.Map<ProjectDTO>(proj);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var existing = await _projectRepository.GetByIdAsync(id);
            if (existing == null)
            {
                throw new Exception("Project not found");
            }
            else
            {
                await _projectRepository.DeleteAsync(id);
                return true;
            }

        }

        public async Task<EmployeeProjectDTO> AssignProjectAsync(EmployeeProjectDTO EmployeeProjectDTO)
        {
            var proj = _mapper.Map<EmployeeProject>(EmployeeProjectDTO);
            var assignproj = await _projectRepository.AssignAsync(proj);
            return _mapper.Map<EmployeeProjectDTO>(assignproj);

        }
    }
}

