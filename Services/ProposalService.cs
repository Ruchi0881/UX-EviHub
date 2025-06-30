using AutoMapper;
using EviHub.Models.Entities;

using Evihub.Repositories;
using Microsoft.EntityFrameworkCore;
using EviHub.DTOs;
using Evihub.Data;

namespace Evihub.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _Repository;
        private readonly IMapper _mapper;
        private readonly EviHubDbContext _context;

        public ProposalService(IProposalRepository Repository, IMapper mapper, EviHubDbContext context)
        {
            _Repository = Repository;
            _mapper = mapper;
            _context = context;
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
        public async Task<IEnumerable<ProposalDTO>> getAllProposalsByEmpId(int Empid)
        {
            var proposals = await _Repository.getAllProposalsByEmpId(Empid);
            return _mapper.Map<IEnumerable<ProposalDTO>>(proposals);
        }
        public async Task<List<ProposalteamsDTO>> GetProposalteams()
        {
            return await _Repository.GetTeamswithProposalId();
        }


    }
}
