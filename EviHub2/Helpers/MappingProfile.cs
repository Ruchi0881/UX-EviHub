using AutoMapper;
using EviHub2.DTOs;
using EviHub2.Models.Entities;

namespace EviHub2.Helpers
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
            CreateMap<Employee,CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee,UpdateEmployeeDTO > ().ReverseMap();
        }
    }
}
