using Evihub.Data;
using EviHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EviHubDbContext _context;
        public LoginRepository(EviHubDbContext context)
        {
            _context = context;
        }
        public async Task<Login> SignupAsync(Login login)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }
        public async Task<Login?> AuthenticateAsync(string email)
        {
            return await _context.Logins
                //.Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Email == email);
        }
    }
}
