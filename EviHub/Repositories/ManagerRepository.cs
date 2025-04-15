using EviHub.Data;
using Microsoft.EntityFrameworkCore;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;

namespace EviHub.Repositories
{
    public class ManagerRepository:IManagerRepository
    {
        private readonly EviHubDbContext _context;

        public ManagerRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager> AddAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> UpdateAsync(int managerId, Manager updatedManager)
        {
            var manager = await _context.Managers.FindAsync(managerId);
            if (manager == null) return null;

            manager.EmpId = updatedManager.EmpId;
            manager.FirstName = updatedManager.FirstName;
            manager.LastName = updatedManager.LastName;
            manager.Mobile = updatedManager.Mobile;
            manager.Email = updatedManager.Email;

            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<bool> DeleteAsync(int managerId)
        {
            var manager = await _context.Managers.FindAsync(managerId);
            if (manager == null) return false;

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}




