using System;
using System.ServiceModel.Configuration;
using WcfRestAuthentication.Services.Api.MessageInspectors;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class ProductEndpointWebHttpBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ProductEndpointWebHttpBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ProductEndpointWebHttpBehavior();
        }
    }
}