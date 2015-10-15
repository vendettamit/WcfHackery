using System.Security.Principal;

namespace WcfRestAuthentication.Services.Api
{
    public interface IAuthenticationProvider
    {
        string Realm { get; }

        IPrincipal Authenticate(string username, string password);
    }
}