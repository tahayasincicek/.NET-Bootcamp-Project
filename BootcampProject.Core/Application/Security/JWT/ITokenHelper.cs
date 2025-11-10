namespace Core.Application.Security.JWT
{
    public interface ITokenHelper
    {
        string CreateToken(int userId, string email, string role);
    }
}
