using AdFrom.Models;
using AdFrom.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class ResponseService : IResponseService
    {
        public async Task<APIData> GetResponse(RequestBodyPart requestBody, RestClient client, string token)
        {
            var request = new RestRequest(Method.POST)
                .AddParameter("Authorization", string.Format("Bearer {0}", token), ParameterType.HttpHeader)
                .AddJsonBody(requestBody);

            var aPIData = JsonConvert.DeserializeObject<APIData>((await client.ExecuteAsync(request)).Content);

            return aPIData;
        }
    }
}
