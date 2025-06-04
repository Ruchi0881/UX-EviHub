using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EviHub2.Models.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Interests { get; set; }
        public int DesignationId { get; set; }
        public int? ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public string GenderId { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsAdmin { get; set; }


        
        public ICollection<Proposal> Proposals { get; set; }//Multiple Proposals
        public ICollection<ProposalWork> ProposalWorks { get; set; }
        public ICollection<Certificationprogress> Certificationprogress { get; set; }
        
       

    }
}
