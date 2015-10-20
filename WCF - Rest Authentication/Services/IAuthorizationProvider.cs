using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using OAuth;
using System.ServiceModel.Channels;
using System.Collections.Specialized;
using System.Web;

namespace WcfRestAuthentication.Services
{
    public interface IAuthorizationProvider
    {
        bool Authenticate(OperationContext operationContext);
    }



}
