namespace EviHub.DTOs
{
    public class SignupRequestDTO
    {
        public int EmpId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public int? ManagerId { get; set; }
        public int DesignationId { get; set; }
     
        public string Password { get; set; }
        
        

    }
}
