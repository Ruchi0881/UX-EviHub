using System.Runtime.ConstrainedExecution;
using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;
using Microsoft.Identity.Client;

namespace EviHub.Services
{
    public class DesignationService:IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly IMapper _mapper;

        public DesignationService(IDesignationRepository designationRepository ,IMapper mapper)
        {
            _designationRepository = designationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DesignationDTO>> GetAllDesignationsAsync()
        {
             var des =await _designationRepository.GetAllAsync();
             return _mapper.Map<List<DesignationDTO>>(des);
        }

        public async Task<DesignationDTO> AddDesignationAsync(DesignationDTO dto)
        {
            var gen = _mapper.Map<Designation>(dto);
            var addedgen  = await _designationRepository.AddAsync(gen);
            return _mapper.Map<DesignationDTO>(addedgen);
        }

        public async Task<DesignationDTO> UpdateDesignationAsync(int id, DesignationDTO dto)
        {
            var existinggen = await _designationRepository.GetByIdAsync(id);
            if (existinggen == null) return null;
            var updated = await _designationRepository.UpdateAsync(id,existinggen);
            return _mapper.Map<DesignationDTO>(updated);
        }
        public async Task<DesignationDTO> GetDesignationByIdAsync(int id)
        {
            var gen = await _designationRepository.GetByIdAsync(id);
            return gen == null ? null : _mapper.Map<DesignationDTO>(gen);
        
        }

        public async Task<bool> DeleteDesignationAsync(int id)
        {
            var existing = await _designationRepository.GetByIdAsync(id);
            if (existing == null)
            {
                throw new Exception("Designation not found");
            }
            else
            {
                await _designationRepository.DeleteAsync(id);
                return true;
            }
        }
    }
  
}

