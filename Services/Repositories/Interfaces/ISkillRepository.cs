using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.Entities;

namespace EviHub.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<EmployeeSkills>> GetSkillsByEmpIdAsync(int empId);
        Task<IEnumerable<Skills>> GetAllSkillsAsync();
        Task<Skills> AddSkillAsync(Skills skill);
        Task UpdateEmployeeSkillsAsync(int empId, List<int> skillIds);
        Task<Skills?> GetSkillByIdAsync(int id);
        Task<bool> DeleteSkillAsync(int id);
        
   

    }
}
