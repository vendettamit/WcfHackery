using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WcfRestAuthentication.Extensions;
using WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors;

namespace WcfRestAuthentication.Services.Api.Endpoints.User.V1.Behaviors
{
    public class UserEndpointWebHttpBehavior : IEndpointBehavior
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

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new ErrorHandler());
            //if (_messageInspectors.Any())
            //    endpointDispatcher.AddMessageInspectors(_messageInspectors);

            //base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new System.NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //throw new System.NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new System.NotImplementedException();
        }
    }
}