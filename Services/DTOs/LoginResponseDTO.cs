namespace EviHub.DTOs
{
    public class LoginResponseDTO
    {
        public int EmpId { get; set; }
        public string Message {  get; set; }
        public string Token  { get; set; }
        public string Role { get; set; }
    }
}
