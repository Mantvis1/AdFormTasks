using AdFrom.Models;
using RestSharp;
using System.Threading.Tasks;

namespace AdFrom.Services.Interfaces
{
    public interface IResponseService
    {
        Task<APIData> GetResponse(RequestBodyPart requestBody);
    }
}
