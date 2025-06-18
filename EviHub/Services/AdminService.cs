using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;

using EviHub.Services.Interfaces;

using EviHub.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EviHub.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenderService _genderService;
        private readonly IManagerService _managerService;
        private readonly IProjectService _projectService;
        private readonly ISkillService _skillService;
        //private readonly ICertificationService _certificationService;
        private readonly IDesignationService _designationService;
        private readonly IMapper _mapper;



        public AdminService(
            IGenderService genderService,
            IManagerService managerService,
            IProjectService projectService,
            ISkillService skillService,
            //ICertificationService certificationService,
            IDesignationService designationService,
            IMapper mapper)
        {
            _genderService = genderService;
            _managerService = managerService;
            _projectService = projectService;
            _skillService = skillService;
            //_certificationService = certificationService;
            _designationService = designationService;
            _mapper = mapper;   
        }

        // === Gender operations ===
        public async Task<IEnumerable<GenderDTO>> GetAllGendersAsync()
        {
             return await _genderService.GetAllGendersAsync();
        }

        public async Task<GenderDTO> GetGenderByIdAsync(int id)
        {
            return await _genderService.GetGenderByIdAsync(id);
        }

        public async Task<GenderDTO> AddGenderAsync([FromBody] GenderDTO dto)
        {
            return await _genderService.AddGenderAsync(dto);
        }

        public async Task<GenderDTO> UpdateGenderAsync(int id, GenderDTO dto)
        {
            return await _genderService.UpdateGenderAsync(id, dto);
        }

        public async Task<bool> DeleteGenderAsync(int id)
        {
            return await _genderService.DeleteGenderAsync(id);
        }

        // === Manager operations ===
        public async Task<IEnumerable<ManagerDTO>> GetAllManagersAsync()
        {
            return await _managerService.GetAllManagersAsync();
        }

        public async Task<ManagerDTO> GetManagerByIdAsync(int id)
        {
            return await _managerService.GetManagerByIdAsync(id);
        }

        public async Task<ManagerDTO> AddManagerAsync(ManagerDTO dto)
        {
            return await _managerService.AddManagerAsync(dto);
        }

        public async Task<ManagerDTO> UpdateManagerAsync(int id, ManagerDTO dto)
        {
            return await _managerService.UpdateManagerAsync(id, dto);
        }

        public async Task<bool> DeleteManagerAsync(int id)
        {
            return await _managerService.DeleteManagerAsync(id);
        }

        // === Project operations ===
        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            return await _projectService.GetAllProjectsAsync();
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            return await _projectService.GetProjectByIdAsync(id);
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto)
        {
            return await _projectService.AddProjectAsync(projectDto);
        }

        public async Task<ProjectDTO> UpdateProjectAsync(int id, ProjectDTO projectDto)
        {
            return await _projectService.UpdateProjectAsync(id, projectDto);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectService.DeleteProjectAsync(id);
        }

        // === Skill operations ===
        public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
        {
            return await _skillService.GetAllSkillsAsync();
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int id)
        {
            return await _skillService.GetSkillByIdAsync(id);
        }

        public async Task<SkillDTO> AddSkillAsync(SkillDTO skillDto)
        {
            return await _skillService.AddSkillAsync(skillDto);
        }

        public async Task<SkillDTO> UpdateSkillAsync(int id, SkillDTO skillDto)
        {
            return await _skillService.UpdateSkillAsync(id, skillDto);
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            return await _skillService.DeleteSkillAsync(id);
        }

        //// === Certification operations ===
        //public async Task<IEnumerable<CertificationDTO>> GetAllCertificationsAsync()
        //{
        //    return await _certificationService.GetAllCertificationsAsync();
        //}

        //public async Task<CertificationDTO> GetCertificationByIdAsync(int id)
        //{
        //    return await _certificationService.GetCertificationByIdAsync(id);
        //}

        //public async Task<CertificationDTO> AddCertificationAsync(CertificationDTO dto)
        //{
        //    return await _certificationService.AddCertificationAsync(dto);
        //}

        //public async Task<CertificationDTO> UpdateCertificationAsync(int id, CertificationDTO dto)
        //{
        //    return await _certificationService.UpdateCertificationAsync(id, dto);
        //}

        //public async Task<bool> DeleteCertificationAsync(int id)
        //{
        //    return await _certificationService.DeleteCertificationAsync(id);
        //}

        // === Designation operations ===
        public async Task<IEnumerable<DesignationDTO>> GetAllDesignationsAsync()
        {
            return await _designationService.GetAllDesignationsAsync();
        }

        public async Task<DesignationDTO> GetDesignationByIdAsync(int id)
        {
            return await _designationService.GetDesignationByIdAsync(id);
        }

        public async Task<DesignationDTO> AddDesignationAsync(DesignationDTO dto)
        {
            return await _designationService.AddDesignationAsync(dto);
        }

        public async Task<DesignationDTO> UpdateDesignationAsync(int id, DesignationDTO dto)
        {
            return await _designationService.UpdateDesignationAsync(id, dto);
        }

        public async Task<bool> DeleteDesignationAsync(int id)
        {
            return await _designationService.DeleteDesignationAsync(id);
        }

       
    }
}
