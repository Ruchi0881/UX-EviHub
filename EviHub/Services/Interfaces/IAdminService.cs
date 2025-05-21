using System.Collections.Generic;
using System.Threading.Tasks;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface IAdminService
    {
        // Gender operations
        Task<IEnumerable<GenderDTO>> GetAllGendersAsync();
        Task<GenderDTO> AddGenderAsync(GenderDTO genderDto);
        Task<GenderDTO> UpdateGenderAsync(int id, GenderDTO genderDto);
        Task<GenderDTO?> GetGenderByIdAsync(int id);
        Task<bool> DeleteGenderAsync(int id);

        // Manager operations
        Task<IEnumerable<ManagerDTO>> GetAllManagersAsync();
        Task<ManagerDTO> AddManagerAsync(ManagerDTO managerDto);
        Task<ManagerDTO> UpdateManagerAsync(int id, ManagerDTO managerDto);
        Task<ManagerDTO?> GetManagerByIdAsync(int id);
        Task<bool> DeleteManagerAsync(int id);

        // Project operations
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto);
        Task<ProjectDTO> UpdateProjectAsync(int id, ProjectDTO projectDto);
        Task<ProjectDTO?> GetProjectByIdAsync(int id);
        Task<bool> DeleteProjectAsync(int id);

        // Skill operations
        Task<IEnumerable<SkillDTO>> GetAllSkillsAsync();
        Task<SkillDTO> AddSkillAsync(SkillDTO skillDto);
        Task<SkillDTO> UpdateSkillAsync(int id, SkillDTO skillDto);
        Task<SkillDTO?> GetSkillByIdAsync(int id);
        Task<bool> DeleteSkillAsync(int id);

        // Certification operations
        Task<IEnumerable<CertificationDTO>> GetAllCertificationsAsync();
        Task<CertificationDTO> AddCertificationAsync(CertificationDTO certificationDto);
        Task<CertificationDTO> UpdateCertificationAsync(int id, CertificationDTO certificationDto);
        Task<CertificationDTO?> GetCertificationByIdAsync(int CertificationId);
        Task<bool> DeleteCertificationAsync(int id);

        // Designation operations
        Task<IEnumerable<DesignationDTO>> GetAllDesignationsAsync();
        Task<DesignationDTO> AddDesignationAsync(DesignationDTO designationDto);
        Task<DesignationDTO> UpdateDesignationAsync(int id, DesignationDTO designationDto);
        Task<DesignationDTO?> GetDesignationByIdAsync(int DesignationId);
        Task<bool> DeleteDesignationAsync(int id);
    }
}



