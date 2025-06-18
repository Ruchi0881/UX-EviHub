using EviHub.Models.Entities;
using Evihub.Data;

using Microsoft.EntityFrameworkCore;
using EviHub.DTOs;

namespace Evihub.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly EviHubDbContext _context;
        public ProposalRepository(EviHubDbContext context) { _context = context; }

        public async Task<IEnumerable<Proposal>> GetAllProposalsAsync()
        {
            return await _context.Proposals.OrderByDescending(p=>p.ProposalDate).ToListAsync();
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
        public async Task<List<ProposalteamsDTO>> GetTeamswithProposalId()
        {
            var data = await (from p in _context.Proposals
                              join e in _context.Employees on p.EmpId equals e.EmpId
                              select new ProposalteamsDTO
                              {
                                  ProposalId = p.ProposalId,
                                  ProposalName = p.ProposalName,
                                  ProposalDescription = p.ProposalDescription,
                                  ProposalDate = p.ProposalDate,
                                  Theme = p.Theme,
                                  Status = p.Status,
                                  Submitter = e.FirstName + " " + e.LastName,
                                  Teams = _context.ProposalWorks
                              .Where(pw => pw.ProposalId == p.ProposalId)
                              .Select(pw => pw.Employee.FirstName + " " + pw.Employee.LastName)
                              .ToList()
                              }).ToListAsync();
            return data;

             


       }




    }
}
