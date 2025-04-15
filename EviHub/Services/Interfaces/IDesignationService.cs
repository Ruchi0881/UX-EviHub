using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IDesignationService
    {
        Task<IEnumerable<Designation>> GetAllDesignationsAsync();
        Task<Designation> AddDesignationAsync(DesignationDTO dto);
        Task<Designation> UpdateDesignationAsync(int id, DesignationDTO dto);
        Task<bool> DeleteDesignationAsync(int id);
    }
}
