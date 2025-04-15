using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class GenderService:IGenderService
    {
        private readonly IGenderRepository _repository;
        public GenderService(IGenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Gender> AddGenderAsync(GenderDTO dto)
        {
            var gender = new Gender { GenderName = dto.GenderName };
            return await _repository.AddAsync(gender);
        }

        public async Task<Gender> UpdateGenderAsync(int Genderid, GenderDTO dto)
        {
            var gender = new Gender { GenderName = dto.GenderName };
            return await _repository.UpdateAsync(Genderid, gender);
        }

        public async Task<bool> DeleteGenderAsync(int Genderid)
        {
            return await _repository.DeleteAsync(Genderid);
        }
    }
}
    

