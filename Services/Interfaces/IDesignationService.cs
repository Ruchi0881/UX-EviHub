using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


namespace EviHub.Services.Interfaces
{
    public interface IDesignationService
    {
        Task<IEnumerable<DesignationDTO>> GetAllDesignationsAsync();
        Task<DesignationDTO> AddDesignationAsync(DesignationDTO dto);
        Task<DesignationDTO> UpdateDesignationAsync(int id, DesignationDTO dto);
        Task<DesignationDTO> GetDesignationByIdAsync(int DesignationId);
        Task<bool> DeleteDesignationAsync(int id);
    }
}
