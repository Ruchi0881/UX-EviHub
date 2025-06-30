using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;


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

                                                                                                                            