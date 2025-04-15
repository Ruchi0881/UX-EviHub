using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task<Manager> AddManagerAsync(ManagerDTO dto);
        Task<Manager> UpdateManagerAsync(int managerId, ManagerDTO dto);
        Task<bool> DeleteManagerAsync(int managerId);
    }
}
