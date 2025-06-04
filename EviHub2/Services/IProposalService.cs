using EviHub2.DTOs;
using EviHub2.Models.Entities;

namespace EviHub2.Services
{
    public interface IProposalService
    {
        Task<IEnumerable<ProposalDTO>> GetAllProposalslAsync();
        Task<ProposalDTO> GetByIdAsync(int id);
        Task<ProposalDTO> AddAsync(ProposalDTO dto);
        Task<ProposalDTO> UpdateProposalAsync(int id,ProposalDTO dto);
        Task<bool> DeleteProposalAsync(int id);
    }
}
