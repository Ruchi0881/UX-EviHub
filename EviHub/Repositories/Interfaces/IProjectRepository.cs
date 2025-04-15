using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> AddAsync(Project project);
        Task<Project> UpdateAsync(int Projectid, Project project);
        Task<bool> DeleteAsync(int Projectid);
    }
}

