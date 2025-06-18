using EviHub.EviHub.Core.Entities.MasterData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.Models.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int EmpProjectId { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public bool IsActive{ get; set; }
        public int  AssignedBy { get; set; }
        //Navigation Properties
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

    }
}
