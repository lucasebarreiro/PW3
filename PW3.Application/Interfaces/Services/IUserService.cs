namespace PW3.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username);
        Task<bool> ValidateUserAsync(string username);

    }
}
