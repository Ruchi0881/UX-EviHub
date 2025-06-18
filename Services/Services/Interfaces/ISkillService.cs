using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


namespace EviHub.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<EmployeeSkillsDTO>> GetSkillsByEmpIdAsync(int empId);
        Task<IEnumerable<SkillDTO>> GetAllSkillsAsync();
        Task<SkillDTO> AddSkillAsync(SkillDTO dto);
        Task <UpdateEmployeeSkillsDTO>UpdateEmployeeSkillsAsync(UpdateEmployeeSkillsDTO dto);
        Task<SkillDTO?> GetSkillByIdAsync(int id);
        
        Task<bool> DeleteSkillAsync(int id);
        Task<List<EmployeeSkillsDTO>> AddEmployeeSkillsAsync(AddEmployeeSkillsDTO dto);
        Task DeleteSkillForEmployeeAsync(int empId, int skillId);
        Task DeleteMultipleSkillForEmployeeAsync(AddEmployeeSkillsDTO dto);

    }
}
