using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public  ICollection<Employee>Employees { get; set; }//One to many(gender can have many employees)
    }
}
