using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Dispatcher;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class TypeConverterInvoker : IOperationInvoker
    {
        private readonly MethodInfo _info;
        readonly IOperationInvoker _invoker;

        public TypeConverterInvoker(IOperationInvoker invoker)
        {
            _invoker = invoker;
        }

        public TypeConverterInvoker(IOperationInvoker invoker, MethodInfo methodInfo)
            : this(invoker)
        {
            _info = methodInfo;
        }

        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs().ToArray();
        }

        private object[] CastCorrections(object[] inputs)
        {
            var outArray = new object[inputs.Length];
            var paramInfo = _info.GetParameters();

            for (int i = 0; i < inputs.Length; i++)
            {
                object typedObject;
                var type = paramInfo[i].ParameterType;
                inputs[i].TryConvertTo(type, out typedObject);
                outArray[i] = typedObject;
            }

            return outArray;
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            return _invoker.Invoke(instance, CastCorrections(inputs), out outputs);
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _invoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _invoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous
        {
            get { return _invoker.IsSynchronous; }
        }
    }
}