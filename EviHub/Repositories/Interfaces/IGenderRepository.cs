using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender> AddAsync(Gender gender);
        Task<Gender> UpdateAsync(int Genderid, Gender gender);
        Task<bool> DeleteAsync(int Genderid);
    }
}
