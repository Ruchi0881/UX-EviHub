using System.ComponentModel.DataAnnotations;

namespace EviHub2.Models.Entities
{
    public class CertificationCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //Navigation Category
        public ICollection<Certification> Certifications { get; set; }
    }
}
