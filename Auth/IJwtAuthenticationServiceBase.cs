namespace TFG_Back.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string email, string password);
    }
}