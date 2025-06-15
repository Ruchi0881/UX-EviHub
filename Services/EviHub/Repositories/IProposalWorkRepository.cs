using EviHub.Models.Entities;

namespace EviHub.Repositories
{
    public interface IProposalWorkRepository
    {
        Task<IEnumerable<ProposalWork>> GetAllAsync();
        Task<ProposalWork> GetByEmpIdAsync(int Empid);
        Task<IEnumerable<ProposalWork>> GetByProposalIdAsync(int proposalid);
        Task<ProposalWork> AddAsync(ProposalWork proposalwork);
        Task<ProposalWork> UpdateAsync(ProposalWork proposalwork);
        Task<bool> DeleteAsync(int proposalid);

    }
}
