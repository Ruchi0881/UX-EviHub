using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public int CategoryId { get; set; }
        public string Status { get;set; }
       
        public ICollection<Employee> Employees { get; set; }//An employee can have many certifications
        
    }
}
