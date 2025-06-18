using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.Models.Entities
{
    public class Proposal
    {
        [Key]
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }
        public string Theme { get; set; }
        public int EmpId { get; set; } //EmpId(FK)
        public string Status { get; set; }
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; } //Navigation property
        public ICollection<ProposalWork> ProposalWorks { get; set; }//Navigation property
    }
}
