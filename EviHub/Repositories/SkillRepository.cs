using EviHub.Data;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly Data.EviHubDbContext _context;
        public  SkillRepository(EviHubDbContext context)
        {
            _context = context;
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
        public async Task<Skills> UpdateSkillAsync(Skills skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            var Skills = await _context.Skills.FindAsync(skillId);
            if (Skills == null) return false;

            _context.Skills.Remove(Skills);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<Skills?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

    }
    
    }

