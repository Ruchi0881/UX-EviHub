using EviHub2.Models.Entities;

namespace EviHub2.Repositories
{
    public interface IProposalRepository
    {
        Task<IEnumerable<Proposal>> GetAllProposalsAsync();
        Task<Proposal> GetProposalByIdAsync(int id);
        Task<Proposal> AddProposalAsync(Proposal proposal);
        Task<Proposal> UpdateProposalAsync(Proposal proposal);
        Task<bool> DeleteProposalAsync(int id);

    }
}
