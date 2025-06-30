using AutoMapper;
using Evihub.Data;
using EviHub.DTOs;
using EviHub.Models.Entities;
using EviHub.Repositories;

namespace EviHub.Services
{
    public class ProposalWorkService : IProposalWorkService
    {
        private readonly IProposalWorkRepository _repo;
        private readonly IMapper _mapper;
        private readonly EviHubDbContext _context;
        public ProposalWorkService(IProposalWorkRepository repo, IMapper mapper, EviHubDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<ProposalWorkDTO>> GetAllAsync()
        {
            var proposal = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProposalWorkDTO>>(proposal);
        }
        public async Task<IEnumerable<ProposalWorkDTO>> GetByEmpIdAsync(int id) 
        {
            var proposal = await _repo.GetByEmpIdAsync(id);
            return _mapper.Map<IEnumerable<ProposalWorkDTO>>(proposal);
        }
        public async Task<IEnumerable<ProposalWorkDTO>> GetByProposalIdAsync(int Proposalid)
        {
            var entity = await _repo.GetByProposalIdAsync(Proposalid);
            return _mapper.Map<IEnumerable<ProposalWorkDTO>>(entity);
        }
        public async Task<ProposalWorkDTO> AddAsync(ProposalWorkDTO dto)
        {

            var entity = _mapper.Map<ProposalWork>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<ProposalWorkDTO>(entity);

        }
        public async Task<ProposalWorkDTO> UpdateAsync( ProposalWorkDTO dto)
        {
            var entity = await _context.ProposalWorks.FindAsync(dto.ProposalId);
            if (entity == null) throw new Exception("Not Found");
            var enti = _mapper.Map<ProposalWork>(dto);
            await _repo.UpdateAsync(enti);
            return _mapper.Map<ProposalWorkDTO>(enti);   

            
        }
        public async Task<bool> DeleteAsync(int id) { return await _repo.DeleteAsync(id); }
    }
}
