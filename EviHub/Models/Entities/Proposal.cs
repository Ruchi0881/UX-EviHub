using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.EviHub.Core.Entities
{
    public class Proposal
    {
        [Key]
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }

        public int EmpId { get; set; } //Proposed By(FK)
        public bool? IsActive { get; set; }
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
        public ICollection<ProposalWork> ProposalWorks { get; set; }
    }
}
