using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRestAuthentication.Services.Api.Endpoints.User
{
   [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="/{UserId}")]
        Model.User Get(Guid userId);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Model.User Post(Model.User user);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        Model.User Put(Model.User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{UserId}")]
        void Delete(Guid userId);

    }
}
