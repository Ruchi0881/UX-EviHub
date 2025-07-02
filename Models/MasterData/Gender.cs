using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EviHub.Models.Entities;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        [ForeignKey("GenderId")]
        public  ICollection<Employee>Employees { get; set; }//One to many(gender can have many employees)
    }
}
