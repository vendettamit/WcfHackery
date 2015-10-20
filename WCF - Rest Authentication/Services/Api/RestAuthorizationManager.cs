using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Threading;

namespace WcfRestAuthentication.Services.Api
{
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            //Extract the Authorization header, and parse out the credentials converting the Base64 string:
            var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            var httpDetails = operationContext.RequestContext.RequestMessage.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            var requestUri = operationContext.RequestContext.RequestMessage.Properties.Via;

            AuthenticationHeader header;

            if(AuthenticationHeader.TryDecode(authHeader, out header))
            {
                /*
                  This would be the place to inject the OAuth authentication manager. 
                */

                if ((header.Username == "user1" && header.Password == "test"))
                {
                    //User is authrized and originating call will proceed
                    return true;
                }
                else
                {
                    //not authorized
                    return false;
                }
            }
            else
            {
                //No authorization header was provided, so challenge the client to provide before proceeding:
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\" Users.Api\"");
                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
}