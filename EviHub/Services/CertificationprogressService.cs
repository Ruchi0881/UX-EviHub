using AutoMapper;
using EviHub.DTOs;
using EviHub.Models.Entities;
using EviHub.Repositories;

namespace EviHub.Services
{
    public class CertificationprogressService : ICertificationprogressService
    {
        private readonly ICertificationprogressRepository _repo;
        private readonly IMapper _mapper;
        public CertificationprogressService(ICertificationprogressRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CertificationprogressDTO>> GetAllAsync()
        {
            var pro = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CertificationprogressDTO>>(pro);
        }
        public async Task<CertificationprogressDTO> GetAsync(int id)
        {
            var pro = await _repo.GetByIdAsync(id);
            return _mapper.Map<CertificationprogressDTO>(pro);
        }
        public async Task<CertificationprogressDTO> AddAsync(CreateCertificationprogressDTO dto)
        {
            var entity = _mapper.Map<Certificationprogress>(dto);
            var added = await _repo.AddAsync(entity);
            return _mapper.Map<CertificationprogressDTO>(added);
        }
        public async Task<bool> UpdateAsync(int id,UpdateCertificationprogressDTO dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.DeleteAsync(id);
            if(entity == false) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
        public async Task<IEnumerable<CertificationprogressDTO>> GetByEmployeeId(int id)
        {
            var pro = await _repo.GetByEmployeeIdAsync(id);
            return _mapper.Map<IEnumerable<CertificationprogressDTO>>(pro);
        }
        public async Task<IEnumerable<CertificationprogressDTO>> GetByCertificationId(int id)
        {
            var pro =  await _repo.GetByCertificationIdAsync(id);
            return _mapper.Map<IEnumerable<CertificationprogressDTO>>(pro);
        }
    }
}
