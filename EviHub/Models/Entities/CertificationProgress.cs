using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class CertificationProgress
    {
        [Key]
        public int CertificationProgressId { get; set; }
        public int CertificationId { get; set; }//FK
        public int EmpId { get; set; }//FK
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       

        //Navigation Property
        public Employee Employee { get; set; }
        public Certification Certification { get; set; }


    }
}
