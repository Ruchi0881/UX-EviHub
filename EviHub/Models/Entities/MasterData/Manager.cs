using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public int EmpId { get; set; }
        public required string FirstName { get; set; }
        public  required string LastName { get; set; }
        public required  string Email { get; set; }
        public required string Mobile { get; set; }
        public ICollection<Employee>EmployeesUnderManager { get; set; }//one to many

    }
}
