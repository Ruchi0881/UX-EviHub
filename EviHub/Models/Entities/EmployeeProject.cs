using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int EmpProjectId { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime AssignedDate { get; set; }
        //Navigation Properties
        public Employee Employee { get; set; }
        public Project Project { get; set; }

    }
}
