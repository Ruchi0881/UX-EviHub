using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

using EviHub.EviHub.Core.Entities;


namespace EviHub.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
           CreateMap<Certification, CertificationDTO>().ReverseMap();
           CreateMap<Employee,EmployeeDTO>().ReverseMap();
           CreateMap<Designation,DesignationDTO>().ReverseMap(); 
           CreateMap<Gender, GenderDTO>().ReverseMap();
           CreateMap<Manager, ManagerDTO>().ReverseMap();
           CreateMap<Project, ProjectDTO>().ReverseMap();
           CreateMap<Skills, SkillDTO>().ReverseMap();
        }

    }
    
}

