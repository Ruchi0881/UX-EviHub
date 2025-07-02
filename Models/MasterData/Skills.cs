using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EviHub.Models.Entities;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Skills
    {
       [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        //[ForeignKey("SkillId")]
        //public ICollection<Employee> Employees { get; set; }//Many to Many
        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }

    }
}
