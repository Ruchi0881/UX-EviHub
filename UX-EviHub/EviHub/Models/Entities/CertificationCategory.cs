using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class CertificationCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //Navigation Category
        public ICollection<Certification> Certifications { get; set; }//One to Many (certificate Category can have multiple certifications)
    }
}
