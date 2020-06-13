using AdFrom.Models;
using RestSharp;
using System.Threading.Tasks;

namespace AdFrom.Services.Interfaces
{
    public interface IResponseService
    {
        Task<string> GetResponse(RequestBodyPart requestBody, RestClient client, string token);
    }
}
