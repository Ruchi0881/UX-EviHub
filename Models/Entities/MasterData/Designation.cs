using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public ICollection<Employee> Employees { get; set; }//one to many (designation can be assigned to many employees)
    }
}
