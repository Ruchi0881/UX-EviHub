using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EviHub.Models.Entities;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        [ForeignKey("DesignationId")]
        public ICollection<Employee> Employee { get; set; }//one to many (designation can be assigned to many employees)
    }
}
