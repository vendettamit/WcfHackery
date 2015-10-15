using System.Security.Principal;

namespace WcfRestAuthentication.Services.Api
{
    internal class AuthorizedAuthenticationProvider : IAuthenticationProvider
    {
        public string Realm { get { return "api.myco.local"; } }

        public IPrincipal Authenticate(string username, string password)
        {
            var principal = new GenericPrincipal(new GenericIdentity(username), new string[] { });
            return principal;
        }
    }
}