using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Skills>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllSkillsAsync();
        }

        public async Task<Skills> AddSkillAsync(SkillDTO skillDto)
        {
            var skill = new Skills
            {
                SkillName = skillDto.SkillName
            };

            return await _skillRepository.AddSkillAsync(skill);
        }

        public async Task<Skills> UpdateSkillAsync(int skillId, SkillDTO skillDto)
        {
            var skill = new Skills
            {
                SkillName = skillDto.SkillName
            };

            return await _skillRepository.UpdateSkillAsync( skill);
             
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            return await _skillRepository.DeleteSkillAsync(skillId);
        }

        public Task<Skills?> GetSkillByIdAsync(int Skillid)
        {
            throw new NotImplementedException();
        }
    }
}
    



