using EviHub.Data;
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

        public async Task<Project> UpdateAsync(int Projectid, Project project)
        {
            var existingProject = await _context.Projects.FindAsync(Projectid);
            if (existingProject == null) return null;

            existingProject.ProjectName = project.ProjectName;

            await _context.SaveChangesAsync();
            return existingProject;
        }

        public async Task<bool> DeleteAsync(int Projectid)
        {
            var project = await _context.Projects.FindAsync(Projectid);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

