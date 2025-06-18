using Evihub.Data;
using EviHub.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class ProposalWorkRepository : IProposalWorkRepository
    {
        private readonly EviHubDbContext _context;
        public ProposalWorkRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProposalWork>> GetAllAsync()
        {
            return await _context.ProposalWorks.ToListAsync();
        }
        public async Task<ProposalWork> GetByEmpIdAsync(int Empid)
        {
            return await _context.ProposalWorks.FindAsync(Empid);
        }
        public async Task<IEnumerable<ProposalWork>> GetByProposalIdAsync(int proposalid)
        {
            return await _context.ProposalWorks.Where(pw => pw.ProposalId == proposalid).ToListAsync();
        }
        public async Task<ProposalWork> AddAsync(ProposalWork proposalwork)
        {
            _context.ProposalWorks.Add(proposalwork);
             await _context.SaveChangesAsync();
            return (proposalwork);
        }
        public async Task<ProposalWork> UpdateAsync(ProposalWork proposalwork)
        {
            _context.ProposalWorks.Update(proposalwork);
            await _context.SaveChangesAsync();
            return (proposalwork);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var proposal = await _context.ProposalWorks.FindAsync(id);
            if (proposal == null) return false;
            _context.ProposalWorks.Remove(proposal);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
