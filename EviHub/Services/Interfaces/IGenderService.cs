using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderDTO>> GetAllGendersAsync();
        Task<GenderDTO> AddGenderAsync(GenderDTO genderDto);
        Task<GenderDTO> UpdateGenderAsync(int id, GenderDTO genderDto);
        Task<GenderDTO?> GetGenderByIdAsync(int id);
        Task<bool> DeleteGenderAsync(int id);
    }
}

                                                                                                                            