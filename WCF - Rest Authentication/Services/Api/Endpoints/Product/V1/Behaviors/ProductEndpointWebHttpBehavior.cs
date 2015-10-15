using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class ProductEndpointWebHttpBehavior : WebHttpBehavior
    {
        private IEnumerable<IDispatchMessageInspector> _messageInspectors { get; set; }

        public ProductEndpointWebHttpBehavior()
        {
            _messageInspectors = new List<IDispatchMessageInspector>();
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

            foreach (var operation in endpoint.Contract.Operations)
            {
                if (operation.Behaviors.Contains(typeof(ProductEndpointWebHttpGetOperationBehavior)))
                    continue;

                operation.Behaviors.Add(new ProductEndpointWebHttpGetOperationBehavior());
            }

            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }

        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription,
            ServiceEndpoint endpoint)
        {
            foreach (var item in operationDescription.Messages[0].Body.Parts)
            {
                item.Type = typeof(string);
            }

            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }
    }
}