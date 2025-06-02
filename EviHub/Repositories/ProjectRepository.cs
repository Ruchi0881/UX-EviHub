using EviHub.Data;
using EviHub.EviHub.Core.Entities;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly EviHubDbContext _context;

        public ProjectRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateAsync(int id, Project project)
        {
            var existingProject = await _context.Projects.FindAsync( id);
            if (existingProject == null) return null;

            existingProject.ProjectName = project.ProjectName;

            await _context.SaveChangesAsync();
            return existingProject;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<EmployeeProject> AssignAsync(EmployeeProject EmployeeProject)
        {
            await _context.EmployeeProjects.AddAsync(EmployeeProject);
            await _context.SaveChangesAsync();
            return EmployeeProject;

        }
    }
}

