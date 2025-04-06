using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class ProposalWork
    {
        [Key]
        public  int ProposalWorkId { get; set; }
        public  int ProposalId { get; set; }//FK
        public  int EmpId { get; set; }//FK
        public bool? IsActive { get; set; }
        //Navigation Properties
        public Employee Employee { get; set; }
        public Proposal Proposal { get; set; }
    }
}
