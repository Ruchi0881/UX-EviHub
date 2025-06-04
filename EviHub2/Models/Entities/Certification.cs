using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub2.Models.Entities
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public int CategoryId { get; set; } //This acts as a foreign key and the name of the variable must be same in both the entities.
        public bool IsActive { get; set; }
        [ForeignKey("CategoryId")]
        public CertificationCategory CertificationCategory { get; set; }

        //public ICollection<Employee> Employees { get; set; }//An employee can have many certifications
        public ICollection<Certificationprogress> Certificationprogress { get; set; }
        
    }
}

