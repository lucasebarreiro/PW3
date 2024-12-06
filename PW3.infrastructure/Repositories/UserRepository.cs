using PW3.Application.Interfaces;
using PW3.infrastructure.Contexts;

namespace PW3.infrastructure.Repositories
{

    public class UserRepository(AppDbContext _context) : IUserRepository;

}
