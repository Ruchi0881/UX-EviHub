using EviHub2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EviHub2.DTOs
{
    public class ProposalDTO
    {
        [Key]
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }


        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }
        public int EmployeeId { get; set; } //EmpId(FK)
        public bool? IsActive { get; set; }
        
     
    }
}
