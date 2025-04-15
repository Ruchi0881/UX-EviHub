using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skills>>GetAllSkillsAsync();
        Task<Skills> AddSkillAsync(SkillDTO dto);
        Task<Skills> UpdateSkillAsync(int id, SkillDTO dto);
        Task<bool> DeleteSkillAsync(int SkillId);
        Task<Skills?> GetSkillByIdAsync(int Skillid);

    }
}
