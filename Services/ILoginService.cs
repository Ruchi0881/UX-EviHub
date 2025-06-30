using EviHub.DTOs;

namespace EviHub.Services
{
    public interface ILoginService
    {
        Task<bool> AuthenticateAsync(LoginRequestDTO loginDTO);
        Task<SignupResponseDTO> SignupAsync(SignupRequestDTO loginDTO);
        Task<LoginResponseDTO>AuthenticateAndGenerateTokenAsync(LoginRequestDTO dto);
    }
}
