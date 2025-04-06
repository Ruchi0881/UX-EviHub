using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Skills
    {
       [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }//Many to Many
    }
}
