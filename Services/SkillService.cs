using AutoMapper;
using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.Entities;
using EviHub.Repositories;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<EmployeeSkillsDTO>> AddEmployeeSkillsAsync(AddEmployeeSkillsDTO dto)
        {
            // Manual mapping: One EmpId, multiple SkillIds
            var newSkills = dto.SkillId.Select(skillId => new EmployeeSkills
            {
                EmpId = dto.EmpId,
                SkillId = skillId
            }).ToList();

            await _skillRepository.AddEmployeeSkillsAsync(newSkills);
            //await _skillRepository.SaveChangesAsync();

            // Optional: map result to DTO
            var result = newSkills.Select(es => new EmployeeSkillsDTO
            {
                EmpId = es.EmpId,
                SkillId = es.SkillId
            }).ToList();

            return result;
        }


        public async Task DeleteSkillForEmployeeAsync(int empId, int skillId)
        {
            await _skillRepository.DeleteSkillForEmployeeAsync(empId, skillId);
        }

        public async Task DeleteMultipleSkillForEmployeeAsync(AddEmployeeSkillsDTO dto)
        {
            foreach (var skillId in dto.SkillId)
            {
                await _skillRepository.DeleteMultipleSkillForEmployeeAsync (dto.EmpId, dto.SkillId);
            }
        }
    }
}
            
            
                

       

         



