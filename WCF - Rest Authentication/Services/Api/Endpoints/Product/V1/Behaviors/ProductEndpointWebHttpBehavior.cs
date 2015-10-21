using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{

    public class ErrorHandler : IErrorHandler
    {
        public bool HandleError(System.Exception error)
        {
            var err = error;
            return true;
        }

        public void ProvideFault(System.Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            var err = error;
        }
    }
    public class ProductEndpointWebHttpBehavior : IEndpointBehavior
    {
        public WebMessageFormat DefaultOutgoingRequestFormat
        {
            get { return defaultOutgoingRequestFormat; }
            set { defaultOutgoingRequestFormat = value; }
        }
        private WebMessageFormat defaultOutgoingRequestFormat;

        public WebMessageFormat DefaultOutgoingResponseFormat
        {
            get { return defaultOutgoingResponseFormat; }
            set { defaultOutgoingResponseFormat = value; }
        }
        private WebMessageFormat defaultOutgoingResponseFormat;

        //private IEnumerable<IDispatchMessageInspector> _messageInspectors { get; set; }

        public ProductEndpointWebHttpBehavior()
        {
            //_messageInspectors = new List<IDispatchMessageInspector>();
            this.defaultOutgoingRequestFormat = WebMessageFormat.Json;
            this.defaultOutgoingResponseFormat = WebMessageFormat.Json;
        }

        public ProductEndpointWebHttpBehavior(IDispatchMessageInspector messageInspector)
            : this(new[] { messageInspector })
        {
        }

        public ProductEndpointWebHttpBehavior(IEnumerable<IDispatchMessageInspector> messageInspectors)
        {
            //_messageInspectors = messageInspectors;
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new ErrorHandler());
            //if (_messageInspectors.Any())
            //    endpointDispatcher.AddMessageInspectors(_messageInspectors);

            //base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new System.NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //throw new System.NotImplementedException();
        }
    }
}