using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WcfRestAuthentication.Services.Api.MessageInspectors
{
    public class ApiServiceAuthenticationMessageInspector : IDispatchMessageInspector
    {
        protected IAuthenticationProvider AuthenticationProvider { get; set; }

        public ApiServiceAuthenticationMessageInspector(IAuthenticationProvider authenticationProvider)
        {
            AuthenticationProvider = authenticationProvider;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return Authenticate(request);
        }

        #region Noop

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //Noop
        }

        #endregion Noop

        #region Private

        private object Authenticate(Message request)
        {
            var req = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            AuthenticationHeader authHeader = null;
            if (AuthenticationHeader.TryDecode(req.Headers["Authorization"], out authHeader)) ;
            {
                var httpContext = new HttpContextWrapper(HttpContext.Current)
                {
                    User = AuthenticationProvider.Authenticate(authHeader.Username, authHeader.Password)
                };
                if (httpContext.User != null)
                {
                    return null;
                }
            }

            //RespondUnauthorized(authHeader.AuthenticationType);
            return null;
        }

        #endregion Private
    }
}