namespace PW3.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username, string password);
        Task<bool> ValidateUserAsync(string username, string password);

    }
}
