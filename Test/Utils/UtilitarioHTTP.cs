using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Test.Utils
{
    public static class UtilitarioHttp
    {
        private static HttpClient CriarHttpClient() =>
            new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { }); }).CreateClient();

        public static async Task<HttpResponseMessage> HttpPostAsync<T>(T requestBody, string uri, string? token = null)
        {
            var client = CriarHttpClient();
            var requestBodyJson = JsonConvert.SerializeObject(requestBody);
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json"),
            };

            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await client.SendAsync(request);
        }
    }
}