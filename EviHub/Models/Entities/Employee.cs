using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class Employee
    {
        [Key]
        //public int Id { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Interests { get; set; }
        public int DesignationId { get; set; }
        public int? ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public int   GenderId { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsAdmin { get; set; }
        
        
        public virtual Manager Manager { get; set; }//Manager of Employee
        public virtual Designation Designation { get; set; }//designation of Employee
        public virtual Project Project { get; set; }//Project of Employee
        public virtual Gender Gender { get; set; }//Gender of Employee
        public virtual Login Login { get; set; }//one to one with Login
        public ICollection<Employee> EmployeesUnderManager { get; set; }//one to many(Employees managed by this employee(Manager)
        public ICollection<EmployeeSkill>EmployeeSkills { get; set; }//Employee can have multiple skills
        public ICollection<EmployeeCertification>EmployeeCertifications { get; set; }//Multiple Certifications
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }//Multiple Projects
        public ICollection<ProposalWork> ProposalWorks { get; set; }//Multiple Proposals
        public ICollection<CertificationProgress> CertificationProgresses { get; set; }//Many to Many
        public ICollection<ProjectProgress> ProjectProgresses { get; set; }//Many to many with Projects


        



    }
}
