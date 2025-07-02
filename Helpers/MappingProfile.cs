using AutoMapper;
using EviHub.Models.Entities;

using EviHub.DTOs;
using EviHub.EviHub.Core.Entities.MasterData;




namespace Evihub.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Proposal, ProposalDTO>().ReverseMap();
            CreateMap<ProposalWork, ProposalWorkDTO>().ReverseMap();
            CreateMap<Certification, CertificationDTO>().ReverseMap();
            CreateMap<CertificationCategory, CertificationCategoryDTO>().ReverseMap();
            CreateMap<CreateCertificationCategoryDTO, CertificationCategory>().ReverseMap();
            CreateMap<CertificationCategoryDTO, CertificationCategory>().ReverseMap();
            CreateMap<Certificationprogress, CertificationprogressDTO>().ReverseMap();
            CreateMap<CreateCertificationprogressDTO, Certificationprogress>().ReverseMap();
            CreateMap<UpdateCertificationprogressDTO, Certificationprogress>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            
     
           
            CreateMap<Certification, CertificationDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Designation, DesignationDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Skills, SkillDTO>().ReverseMap();
            CreateMap<EmployeeSkills, EmployeeSkillsDTO>()
            .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.SkillId))
            .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmpId));
            CreateMap<Login, LoginResponseDTO>()
            .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.Employee.EmpId))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src =>
                src.Employee.IsAdmin == true ? "Admin" :
                src.Employee.ManagerId != null ? "Manager" : "Employee"));
            
            CreateMap<SignupRequestDTO, Employee>()
    //.ForMember(dest => dest.CertificationId, opt => opt.Ignore())
    .ForMember(dest => dest.DOJ, opt => opt.Ignore())
    //.ForMember(dest => dest.DesignationId, opt => opt.Ignore()) // if not in signup
    .ForMember(dest => dest.ProjectId, opt => opt.Ignore())     // same here
    //.ForMember(dest => dest.SkillId, opt => opt.Ignore())       // etc.
    .ForMember(dest => dest.IsAdmin, opt => opt.Ignore());      // optional if not passed





        }

    }
}
