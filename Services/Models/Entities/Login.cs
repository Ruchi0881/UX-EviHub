using System.ComponentModel.DataAnnotations.Schema;

namespace EviHub.Models.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        [Column("Email")]
        public string Email{ get; set; }
        public string Password  { get; set; }
        public int EmpId { get; set; }//FK
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }  
    }
}
