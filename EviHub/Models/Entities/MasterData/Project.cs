using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Project
    {
        [Key]
        public int ProjectId { get;set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool? IsActive { get; set; }
        //public int EmpId { get; set; }//FK
        //Navigation Property
       
        public ICollection<Employee> Employees { get; set; }//one to many(A project can be assigned to many employees)
        public ICollection<EmployeeProject> EmployeeProject { get; set; }//Many to many  relationwith Employess
         
    }
}
