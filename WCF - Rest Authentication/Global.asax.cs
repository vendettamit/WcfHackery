using System;
using System.Web.Routing;
using System.ServiceModel.Activation;
using WcfRestAuthentication.Services.Api;
using WcfRestAuthentication.Services;

namespace WcfRestAuthentication
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MapRoutes(RouteTable.Routes);

            //AuthContext.SetAuthorizationProvider(() => new OAuthAuthenticationProvider());
            AuthContext.SetAuthorizationProvider(() => new BasicAuthenticationProvider());
        }

        private void MapRoutes(RouteCollection routes)
        {
            routes.Add(new ServiceRoute("api", new ServiceHostFactory(), typeof(ApiService)));
        }
    }
}