using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities.MasterData
{
    public class Managers
    {
        [Key]
        public int ManagerId { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public ICollection<Employee>EmployeesUnderManager { get; set; }//one to many

    }
}
