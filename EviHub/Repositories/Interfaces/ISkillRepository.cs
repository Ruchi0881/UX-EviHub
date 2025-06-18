using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skills>> GetAllSkillsAsync();
        Task<Skills> AddSkillAsync(Skills skill);
        Task<Skills> UpdateSkillAsync( int id ,Skills skill);
        Task<Skills?> GetSkillByIdAsync(int id);
        Task<bool> DeleteSkillAsync(int id);
   

    }
}
