using System.ServiceModel;
using WebApi.Models;

namespace WebApi.Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string RegisterUser(User user);
    }
}