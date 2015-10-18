using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class ProductEndpointWebHttpBehavior : WebHttpBehavior
    {
        public override WebMessageFormat DefaultOutgoingRequestFormat
        {
            get { return defaultOutgoingRequestFormat; }
            set { defaultOutgoingRequestFormat = value; }
        }
        private WebMessageFormat defaultOutgoingRequestFormat;

        public override WebMessageFormat DefaultOutgoingResponseFormat
        {
            get { return defaultOutgoingResponseFormat; }
            set { defaultOutgoingResponseFormat = value; }
        }
        private WebMessageFormat defaultOutgoingResponseFormat;

        private IEnumerable<IDispatchMessageInspector> _messageInspectors { get; set; }

        public ProductEndpointWebHttpBehavior()
        {
            _messageInspectors = new List<IDispatchMessageInspector>();
            this.defaultOutgoingRequestFormat = WebMessageFormat.Json;
            this.defaultOutgoingResponseFormat = WebMessageFormat.Json;
        }

        public ProductEndpointWebHttpBehavior(IDispatchMessageInspector messageInspector)
            : this(new[] { messageInspector })
        {
        }

        public ProductEndpointWebHttpBehavior(IEnumerable<IDispatchMessageInspector> messageInspectors)
        {
            _messageInspectors = messageInspectors;
        }

        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            if (_messageInspectors.Any())
                endpointDispatcher.AddMessageInspectors(_messageInspectors);

            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }

        public override void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}