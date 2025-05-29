namespace EviHub.Models.DTO_s
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Interests { get; set; }
        public int DesignationId { get; set; }
        public int? ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public int GenderId { get; set; }
        public int SkillId { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
