using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.User.V1.Behaviors
{
    public class UserEndpointWebHttpBehavior : WebHttpBehavior
    {
        private IEnumerable<IDispatchMessageInspector> _messageInspectors { get; set; }

        public UserEndpointWebHttpBehavior()
            : this(new List<IDispatchMessageInspector>())
        { }

        public UserEndpointWebHttpBehavior(IDispatchMessageInspector messageInspector)
            : this(new[] { messageInspector })
        { }

        public UserEndpointWebHttpBehavior(IEnumerable<IDispatchMessageInspector> messageInspectors)
        {
            _messageInspectors = messageInspectors;
        }

        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            if (_messageInspectors.Any())
                endpointDispatcher.AddMessageInspectors(_messageInspectors);

            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }
    }
}