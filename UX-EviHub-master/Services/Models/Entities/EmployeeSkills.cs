using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Models.Entities
{
    public class EmployeeSkills
    {
        [Key]
        public int EmployeeSkillId { get; set; }
        public int EmpId { get; set; }
        public int SkillId { get; set; }

        [ForeignKey("EmpId")]
        public Employee Employee{get;set;}
        [ForeignKey("SkillId")]
        public Skills Skills { get; set;}
    }
}
