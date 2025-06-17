using EviHub.Models.Entities;

namespace EviHub.Repositories
{
    public interface ILoginRepository
    {
        Task<Login>SignupAsync(Login login);
        Task<Login> AuthenticateAsync (string email);
    }

}
