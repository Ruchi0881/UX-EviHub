using AutoMapper;
using EviHub.DTOs;
using EviHub.Models.Entities;
using EviHub.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _Repository;
        private readonly IMapper _mapper;

        public ProposalService(IProposalRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProposalDTO>> GetAllProposalslAsync()
        {
            var proposal = await _Repository.GetAllProposalsAsync();
            return _mapper.Map<IEnumerable<ProposalDTO>>(proposal);
        }
        public async Task<ProposalDTO> GetByIdAsync(int id)
        {
            var proposal = await _Repository.GetProposalByIdAsync(id);
            return _mapper.Map<ProposalDTO>(proposal);
        }
        public async Task<ProposalDTO> AddAsync(ProposalDTO dto)
        {

            var entity = _mapper.Map<Proposal>(dto); 
            await _Repository.AddProposalAsync(entity);
            return _mapper.Map<ProposalDTO>(entity);

        }
        public async Task<ProposalDTO> UpdateProposalAsync(int id,ProposalDTO dto)
        {
            var update = _mapper.Map<Proposal>(dto);
            update.ProposalId = id;
            await _Repository.UpdateProposalAsync(update);
            return _mapper.Map<ProposalDTO>(update);
        }
        public async Task<bool> DeleteProposalAsync(int id) { return await _Repository.DeleteProposalAsync(id); }
        
    }
}
