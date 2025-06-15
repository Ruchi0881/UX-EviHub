using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


namespace EviHub.Services.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ManagerDTO>> GetAllManagersAsync();
        Task<ManagerDTO> AddManagerAsync(ManagerDTO dto);
        Task<ManagerDTO> UpdateManagerAsync(int Id, ManagerDTO dto);
        Task<ManagerDTO?> GetManagerByIdAsync(int Id);
        Task<bool> DeleteManagerAsync(int id);
    }
}
