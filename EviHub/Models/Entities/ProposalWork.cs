using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.Models.Entities
{
    public class ProposalWork
    {
        [Key]
        public int ProposalWorkId { get; set; }
        public int ProposalId { get; set; }//FK
        public int EmpId { get; set; }//FK
        public bool? IsActive { get; set; }

        //Navigation Properties
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
        public Proposal Proposal { get; set; }
    }
}
