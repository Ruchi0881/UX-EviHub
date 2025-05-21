using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderrepository;
        private readonly IMapper _mapper;
        public GenderService(IGenderRepository genderrepository,IMapper mapper)
        {
            _genderrepository = genderrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenderDTO>> GetAllGendersAsync()
        {
            var gen = await _genderrepository.GetAllAsync();
            return _mapper.Map<List<GenderDTO>>(gen);
        }

        public async Task<GenderDTO> AddGenderAsync(GenderDTO dto)
        {
            var gen = _mapper.Map<Gender>(dto);
            var addedgen =await _genderrepository.AddAsync(gen);
            return _mapper.Map<GenderDTO>(addedgen);
        }

        public async Task<GenderDTO> UpdateGenderAsync(int id, GenderDTO dto)
        {
            var existinggen = await _genderrepository.GetByIdAsync(id);
            if (existinggen != null) return null;
            existinggen.GenderName = dto.GenderName;
            var updated = await _genderrepository.UpdateAsync(id,existinggen);
            return _mapper.Map<GenderDTO>(updated);
        }
        public async Task<GenderDTO> GetGenderByIdAsync(int id)
        {
            var gen  = await _genderrepository.GetByIdAsync(id);
            return gen == null ? null : _mapper.Map<GenderDTO>(gen);
        }

        public async Task<bool> DeleteGenderAsync(int id)
        {
            var existing = await _genderrepository.GetByIdAsync(id);
            if (existing == null) 
            {
                throw new Exception("Gender not found");
            }
            else
            {
                await _genderrepository.DeleteAsync(id);
                return true;
            }
        }

    }
}
    

