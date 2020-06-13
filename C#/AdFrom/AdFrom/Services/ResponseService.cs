using AdFrom.Models;
using AdFrom.Services.Interfaces;
using RestSharp;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class ResponseService : IResponseService
    {
        public async Task<string> GetResponse(RequestBodyPart requestBody, RestClient client, string token)
        {
            var request = new RestRequest(Method.POST)
                .AddParameter("Authorization", string.Format("Bearer " + token), ParameterType.HttpHeader);
            
            request.AddJsonBody(requestBody);

            return (await client.ExecuteAsync(request)).Content;
        }
    }
}
