using EviHub.DTOs;
using EviHub2.Models.Entities;

namespace EviHub.Services
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
