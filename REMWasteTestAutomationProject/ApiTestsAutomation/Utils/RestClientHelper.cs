using NUnit.Framework;
using RestSharp;

namespace ApiTestsAutomation.Utils
{
    public class RestClientHelper
    {
        private readonly RestClient client;
        public RestClientHelper(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public RestResponse ExecuteGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = client.Execute(request);

            LogRequestAndResponse(request, response);
            return response;
        }

        public RestResponse ExecutePostRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);
            var response = client.Execute(request);

            LogRequestAndResponse(request, response);
            return response;
        }

        public RestResponse ExecutePutRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            var response = client.Execute(request);

            LogRequestAndResponse(request, response);
            return response;
        }

        public RestResponse ExecuteDeleteRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            var response = client.Execute(request);

            LogRequestAndResponse(request, response);
            return response;
        }

        private void LogRequestAndResponse(RestRequest request, RestResponse response)
        {
            var jsonBody = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value ?? "No payload";
            TestContext.WriteLine($"Request: {request.Resource}");
            TestContext.WriteLine($"Payload: {jsonBody}");
            TestContext.WriteLine($"Response: {response.Content}");
        }
    }
}
