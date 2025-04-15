using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skills>> GetAllSkillsAsync();
        Task<Skills> AddSkillAsync(Skills skill);
        Task<Skills> UpdateSkillAsync(Skills skill);
        Task<bool> DeleteSkillAsync(int SkillId);
        Task<Skills?> GetSkillByIdAsync(int Skillid);

    }
}
