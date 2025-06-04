using System.ComponentModel.DataAnnotations;

namespace EviHub2.DTOs
{
    public class EmployeeDTO
    {


        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


    }
    public class CreateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Interests { get; set; }
        public int DesignationId { get; set; }
        public int? ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public string GenderId { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsAdmin { get; set; }

        public class UpdateEmployeeDTO : CreateEmployeeDTO
        {
            public int EmployeeId { get; set; }
        }
    }
}