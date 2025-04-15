using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class ProjectProgress
    {
        [Key]
        public int EmpProjectProgressId { get; set; }
        public int ProjectId { get; set; }//FK
        public int EmpId { get; set; }//FK
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //Navigation Properties
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        

    }
}
