
using EviHub.DTOs;
using EviHub.Models.Entities;


namespace Evihub.Services
{
    public interface IProposalService
    {
        Task<IEnumerable<ProposalDTO>> GetAllProposalslAsync();
        Task<ProposalDTO> GetByIdAsync(int id);
        Task<ProposalDTO> AddAsync(ProposalDTO dto);
        Task<ProposalDTO> UpdateProposalAsync(int id,ProposalDTO dto);
        Task<bool> DeleteProposalAsync(int id);
        Task<IEnumerable<ProposalDTO>> getAllProposalsByEmpId(int Empid);
    }
}
