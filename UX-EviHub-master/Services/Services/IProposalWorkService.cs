using EviHub.DTOs;
using EviHub.Models.Entities;

namespace EviHub.Services
{
    public interface IProposalWorkService
    {

        Task<IEnumerable<ProposalWorkDTO>> GetAllAsync();
        Task<IEnumerable<ProposalWorkDTO>> GetByEmpIdAsync(int Empid);
         Task<IEnumerable<ProposalWorkDTO>> GetByProposalIdAsync(int proposalid);
        Task<ProposalWorkDTO> AddAsync(ProposalWorkDTO dto);
        Task<ProposalWorkDTO> UpdateAsync(ProposalWorkDTO dto);
        Task<bool> DeleteAsync(int proposalid);


    }
}


