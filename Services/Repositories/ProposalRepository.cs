using EviHub.Models.Entities;
using Evihub.Data;

using Microsoft.EntityFrameworkCore;

namespace Evihub.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly EviHubDbContext _context;
        public ProposalRepository(EviHubDbContext context) { _context = context; }

        public async Task<IEnumerable<Proposal>> GetAllProposalsAsync()
        {
            return await _context.Proposals.ToListAsync();
        }
        public async Task<Proposal> GetProposalByIdAsync(int id)
        {
            return await _context.Proposals.Where(x => x.ProposalId == id)
                .Include(x => x.ProposalWorks).FirstOrDefaultAsync();
        }
        public async Task<Proposal> AddProposalAsync(Proposal proposal)
        {
            _context.Proposals.Add(proposal);
            await _context.SaveChangesAsync();
            return proposal;
        }
        public async Task<Proposal>  UpdateProposalAsync(Proposal proposal)
        {
            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();
            return proposal;
        }
        public async Task<bool> DeleteProposalAsync(int id)
        {
            var proposal = await _context.Proposals.FindAsync(id);
            if(proposal == null) return false;
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Proposal>> getAllProposalsByEmpId(int Empid)
        {
            return await _context.Proposals.Where(p=>p.EmpId == Empid).ToListAsync();
        }

        
    }
}
