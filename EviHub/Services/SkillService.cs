using AutoMapper;
using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories;
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

        public async Task<List<EmployeeSkillsDTO>> GetSkillsByEmpIdAsync(int empId)
        {
            var employeeSkills = await _skillRepository.GetSkillsByEmpIdAsync(empId);
            return _mapper.Map<List<EmployeeSkillsDTO>>(employeeSkills);
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
        public async Task<UpdateEmployeeSkillsDTO> UpdateEmployeeSkillsAsync(UpdateEmployeeSkillsDTO dto)
        {
            await _skillRepository.UpdateEmployeeSkillsAsync(dto.EmpId, dto.SkillIds);

            // Return mapped response using AutoMapper
            return _mapper.Map<UpdateEmployeeSkillsDTO>(dto);
        }


        //public async Task<EmployeeSkillsDTO> UpdateEmployeeSkillsAsync(UpdateEmployeeSkillsDTO dto)
        //{
        //    var employeeSkills = await _skillRepository.UpdateEmployeeSkillsAsync(dto.EmpId);

        //    // Update logic: remove old entries, add new ones, etc.
        //    await _employeeSkillsRepository.UpdateByEmpIdAsync(dto.EmpId, dto.SkillIds); // example logic

        //    // Return a mapped result
        //    var resultDto = new EmployeeSkillsDTO
        //    {
        //        EmpId = dto.EmpId,
        //        SkillIds = dto.SkillIds
        //    };

        //    return resultDto;
        //}

        //var existingskill = await _skillRepository.GetSkillByIdAsync(SkillId);
        //if (existingskill == null) ;

        //existingskill.SkillName = skillDto.SkillName;

        //var updatedskill = await _skillRepository.UpdateEmployeeSkillsAsync(id, existingskill);
        //return _mapper.Map<SkillDTO>(updatedskill);


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
            
            
                

       

         



