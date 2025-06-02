using System.Runtime.ConstrainedExecution;
using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EviHub.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IMapper _mapper;

        public CertificationService(ICertificationRepository certificationRepository,IMapper mapper)
        {
            _certificationRepository = certificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificationDTO>> GetAllCertificationsAsync()
        {
            var cert = await _certificationRepository.GetAllAsync();
            return _mapper.Map<List<CertificationDTO>>(cert);
        }

        public async Task<CertificationDTO> AddCertificationAsync(CertificationDTO dto)
        {
            var cert = _mapper.Map<Certification>(dto);
            var addedcert = await _certificationRepository.AddAsync(cert);
            return _mapper.Map<CertificationDTO>(addedcert);
            
          
        }

  
        public async Task<CertificationDTO> UpdateCertificationAsync(int id, CertificationDTO dto)
        {
            var existingcert = await _certificationRepository.GetByIdAsync(id);
            if (existingcert == null) return null;

            existingcert.CertificationName = dto.CertificationName;
            existingcert.CategoryId = dto.CategoryId;
            existingcert.Status = dto.Status;

            var updated = await _certificationRepository.UpdateAsync(id, existingcert);
            return _mapper.Map<CertificationDTO>(updated);
        }

        public async Task <CertificationDTO> GetCertificationByIdAsync (int id)
        {
            var cert = await _certificationRepository.GetByIdAsync(id);
            return cert == null ? null :_mapper.Map<CertificationDTO>(cert);    

        }

        public async Task<bool>  DeleteCertificationAsync(int id)
        {
            var existing = await _certificationRepository.GetByIdAsync (id);
            if (existing == null)
            {
                throw new Exception("Certification Not Found");
            }
            else
            {
                await _certificationRepository.DeleteAsync(id);
                return true;
            }
            
        }

    }
}

