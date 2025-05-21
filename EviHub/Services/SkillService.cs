using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
        {
            var skill = await _skillRepository.GetAllSkillsAsync();
            return _mapper.Map<List<SkillDTO>>(skill);
        }

        public async Task<SkillDTO> AddSkillAsync(SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skills>(skillDto);
            var addedskill = await _skillRepository.AddSkillAsync(skill);
            return _mapper.Map<SkillDTO>(addedskill);
        }

        public async Task<SkillDTO> UpdateSkillAsync(int id, SkillDTO skillDto)
        {
            var existingskill = await _skillRepository.GetSkillByIdAsync(id);
            if (existingskill != null) ;

            existingskill.SkillName = skillDto.SkillName;

            var updatedskill = await _skillRepository.UpdateSkillAsync(id, existingskill);
            return _mapper.Map<SkillDTO>(updatedskill);

        }
        public async Task<SkillDTO?> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(id);
            return skill == null ? null : _mapper.Map<SkillDTO?>(skill);
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var existing = await _skillRepository.GetSkillByIdAsync(id);
            if (existing == null)
            {
                throw new Exception("Skill not found");
            }
            else
            {
                await _skillRepository.DeleteSkillAsync(id);
                return true;
            }
        }
    }
}
            
            
                

       

         



