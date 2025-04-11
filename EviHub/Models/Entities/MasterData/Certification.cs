using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get;set; }
        public CertificationCategory CertificationCategory { get; set; }
        public ICollection<Employee> Employees { get; set; }//An employee can have many certifications
        public ICollection<CertificationProgress> CertificationProgresses { get; set; }//Many to Many with Employees
        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }//Many to Many with Employees
    }
}
