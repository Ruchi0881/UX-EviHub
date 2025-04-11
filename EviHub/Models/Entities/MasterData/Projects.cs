using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Projects
    {
        [Key]
        public int ProjectId { get;set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool? IsActive { get; set; }
        //Navigation Property
        public ICollection<Employee> Employees { get; set; }//one to many(A project can be assigned to many employees)
        public ICollection<ProjectProgress> ProjectProgresses { get; set; }//Many to many  relationwith Employess
         
    }
}
