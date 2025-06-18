using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


namespace EviHub.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDTO>>GetAllSkillsAsync();
        Task<SkillDTO> AddSkillAsync(SkillDTO dto);
        Task<SkillDTO> UpdateSkillAsync(int id, SkillDTO dto);
        Task<SkillDTO?> GetSkillByIdAsync(int id);
        Task<bool> DeleteSkillAsync(int id);
       

    }
}
