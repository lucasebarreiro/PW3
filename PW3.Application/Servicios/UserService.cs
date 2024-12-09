using PW3.Application.Interfaces;
using PW3.Domain.Models;

namespace PW3.Application.Servicios
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (await _userRepository.ExistsByUsernameAsync(username, CancellationToken.None))
                return false;

            var user = new User
            {
                Username = username,
                Password = password
            };

            await _userRepository.AddAsync(user, CancellationToken.None);
            return true;

        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username, CancellationToken.None);
            return user != null && (user.Password == password);

        }
    }
}
