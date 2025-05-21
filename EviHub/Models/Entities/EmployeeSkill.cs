
using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }
        public int EmpId { get; set; }//FK
        public int SkillId { get; set; }//FK
        //Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Skills Skills { get; set; }
    }
}
