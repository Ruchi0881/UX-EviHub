using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EviHub.EviHub.Core.Entities
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        public int EmpId { get; set; }//FK
        public string UserName { get; set; }
        public string PasswordHash { get; set;}//hashed password
        //Navigation Properties
        public Employee Employee { get; set; }//links to employee
    }
}
