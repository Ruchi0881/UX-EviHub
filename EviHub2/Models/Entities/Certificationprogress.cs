using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub2.Models.Entities
{
    public class Certificationprogress
    {
        [Key]
        public int CertificationProgressId { get; set; }
        public int CertificationId { get; set; }//FK
        public int EmployeeId { get; set; }//FK
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }


        //Navigation Property
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("CertificationId")]
        public Certification Certification { get; set; }
    }
}
