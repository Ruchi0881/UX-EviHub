using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace EviHub.Services
{
    public class DesignationService:IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;

        public DesignationService(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<IEnumerable<Designation>> GetAllDesignationsAsync()
        {
            return await _designationRepository.GetAllAsync();
        }

        public async Task<Designation> AddDesignationAsync(DesignationDTO dto)
        {
            var designation = new Designation
            {
                DesignationName = dto.DesignationName
            };

            return await _designationRepository.AddAsync(designation);
        }

        public async Task<Designation> UpdateDesignationAsync(int id, DesignationDTO dto)
        {
            var updatedDesignation = new Designation
            {
                DesignationName = dto.DesignationName
            };

            return await _designationRepository.UpdateAsync(id, updatedDesignation);
        }

        public async Task<bool> DeleteDesignationAsync(int id)
        {
            return await _designationRepository.DeleteAsync(id);
        }
    }
  
}

