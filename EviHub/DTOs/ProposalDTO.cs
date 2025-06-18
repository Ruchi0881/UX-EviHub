
using System.ComponentModel.DataAnnotations;

namespace EviHub.DTOs
{
    public class ProposalDTO
    {
        [Key]
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }
        public int EmpId { get; set; } //EmpId(FK)
        public string Theme { get; set; }

        public string Status { get; set; }


    }
    public class ProposalteamsDTO
    {
        public int ProposalId { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime ProposalDate { get; set; }
        public string Theme { get; set; }
        public string Status { get; set; }


        public string Submitter { get; set; }
        public List<string> Teams { get; set; }


    }

}