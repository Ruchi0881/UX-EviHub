using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        Task<Gender> AddGenderAsync(GenderDTO genderDto);
        Task<Gender> UpdateGenderAsync(int Genderid, GenderDTO genderDto);
        Task<bool> DeleteGenderAsync(int Genderid);
    }
}

