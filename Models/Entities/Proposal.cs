using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class Proposal
    {
        [Key]
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }
        public int ProposedBy { get; set; } //EmpId(FK)
        public bool? IsActive { get; set; }
        public Employee Employee { get; set; }
        public ICollection<ProposalWork> ProposalWorks { get; set; }
    }
}
