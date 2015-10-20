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
            if (AuthContext.Current == null)
            {
                return base.CheckAccess(operationContext);
            }

            return AuthContext.Current.Authenticate(operationContext);
        }
    }
}