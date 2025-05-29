using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        
      
        public string RoleName { get; set; }

        //Navigation Properties
        //public UserRole UserRoles { get; set; }
        //public Employee Employee { get; set; }
        public ICollection<Employee> Employees { get; set; }//employee -roles(Many to Many)
    }
}
