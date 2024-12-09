namespace PW3.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username, string password);
        Task<bool> ValidateUserAsync(string username, string password);

    }
}
