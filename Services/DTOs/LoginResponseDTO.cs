namespace EviHub.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public int EmpId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
