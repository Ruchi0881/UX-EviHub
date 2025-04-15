namespace EviHub.Models.DTO_s
{
    public class ManagerDTO
    {
        public int ManagerId { get; set; }
        public int EmpId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Mobile { get; set; }
    }
}
