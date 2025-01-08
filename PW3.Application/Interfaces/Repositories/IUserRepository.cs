using PW3.Domain.Models;

namespace PW3.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllAsync();
    }
}

