
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
using Evihub.Data;
using Microsoft.EntityFrameworkCore;
using EviHub.Models.Entities;
using EviHub.DTOs;

namespace EviHub.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly EviHubDbContext _context;

        public  SkillRepository(EviHubDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeSkills>> GetSkillsByEmpIdAsync(int empId)
        {
            return await _context.EmployeeSkills
                .Include(es => es.Skills)
                .Where(es => es.EmpId == empId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Skills>> GetAllSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }
        public async Task<Skills>AddSkillAsync(Skills skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task UpdateEmployeeSkillsAsync(int empId, List<int> skillIds)
        {
            try
            {
                // Remove old skills
                var existing = await _context.EmployeeSkills
                    .Where(es => es.EmpId == empId)
                    .ToListAsync();

                _context.EmployeeSkills.RemoveRange(existing);

                // Add new skills
                var newSkills = skillIds.Select(skillId => new EmployeeSkills
                {
                    EmpId = empId,
                    SkillId = skillId
                }).ToList();

                await _context.EmployeeSkills.AddRangeAsync(newSkills);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }






        public async Task<Skills?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills
                .FirstOrDefaultAsync(s =>s.SkillId == id);
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            var Skills = await _context.Skills.FindAsync(skillId);
            if (Skills == null) return false;

            _context.Skills.Remove(Skills);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddEmployeeSkillsAsync(List<EmployeeSkills> skills)
        {
            await _context.EmployeeSkills.AddRangeAsync(skills);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkillForEmployeeAsync(int empId, int skillId)
        {
            var skillToRemove = await _context.EmployeeSkills
                .FirstOrDefaultAsync(es => es.EmpId == empId && es.SkillId == skillId);

            if (skillToRemove != null)
            {
                _context.EmployeeSkills.Remove(skillToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMultipleSkillForEmployeeAsync(int empId, List<int> skillId)
        {
            var skillsToRemove = await _context.EmployeeSkills
                .Where(es => es.EmpId == empId && skillId.Contains(es.SkillId))
                .ToListAsync();

            _context.EmployeeSkills.RemoveRange(skillsToRemove);
            await _context.SaveChangesAsync();
        }

    }
    
}

