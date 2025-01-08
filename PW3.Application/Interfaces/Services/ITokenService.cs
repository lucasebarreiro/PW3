namespace PW3.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
