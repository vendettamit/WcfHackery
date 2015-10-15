using System;
using System.ServiceModel.Configuration;
using WcfRestAuthentication.Services.Api.MessageInspectors;

namespace WcfRestAuthentication.Services.Api.Endpoints.User.V1.Behaviors
{
    public class UserEndpointWebHttpBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(UserEndpointWebHttpBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new UserEndpointWebHttpBehavior();
        }
    }
}