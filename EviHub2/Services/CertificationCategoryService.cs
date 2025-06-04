using AutoMapper;
using EviHub.DTOs;
using EviHub.Models.Entities;
using EviHub.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EviHub.Services
{
    public class CertificationCategoryService : ICertificationCategoryService
    {
        private readonly ICertificationCategoryRepository _repo;
        private readonly IMapper _mapper;
        public CertificationCategoryService(ICertificationCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper =mapper;
        }
        public async Task<IEnumerable<CertificationCategoryDTO>> GetAllAsync()
        {
            var cat = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CertificationCategoryDTO>>(cat);
        }
        public async Task<CertificationCategoryDTO> GetByIdAsync(int id)
        {
            var cat = await _repo.GetByIdAsync(id);
            return _mapper.Map<CertificationCategoryDTO>(cat);

            

        }
        public async Task<CertificationCategoryDTO> AddAsync(CreateCertificationCategoryDTO dto)
        {
            var cate= _mapper.Map<CertificationCategory>(dto);
            var cat= await _repo.AddAsync(cate);
            return _mapper.Map<CertificationCategoryDTO>(cat);

        }
        public async Task<bool> UpdateAsync(int id, UpdateCertificationCategoryDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            existing.CategoryName=dto.CategoryName;
            
            return  await _repo.UpdateAsync(existing);
        }
        public async Task<bool> DeleteAsync(int id) =>
        
            await _repo.DeleteAsync(id);


        public async Task<IEnumerable<Certification>> GetCertificationsByCategoryId(int id) =>

            await _repo.GetCertificationsByCategoryId(id);
        
        
    }
}
