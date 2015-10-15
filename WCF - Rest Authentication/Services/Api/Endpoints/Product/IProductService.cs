using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product
{
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{categoryId}?pageIndex={pageIndex}&pageSize={pageSize}")]
        IEnumerable<Model.Product> GetList(Guid categoryId, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        Model.Product Put(Model.Product product);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{productId}")]
        Model.Product Get(Guid productId);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Model.Product Post(Model.Product product);
        
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{productId}")]
        void Delete(Guid productId);
    }
}