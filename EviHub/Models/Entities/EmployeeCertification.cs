using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class EmployeeCertification
    {
        [Key]
        public int EmpCertId { get; set; }
        public int EmpId { get; set; }
        public int CategoryId { get; set; }//FK
        public int CertificationId { get; set; }//FK
        //Navigation Properties
        public Employee Employee { get; set; }
        public Certification Certifications { get; set; }
    }
}
