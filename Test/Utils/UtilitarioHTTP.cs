using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Test.Utils
{
    public static class UtilitarioTest
    {
        private static WebApplicationFactory<Program> ObterWebApplication() =>
            new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { }); });

        private static HttpClient CriarHttpClient() => ObterWebApplication().CreateClient();
        

        public static async Task<HttpResponseMessage> HttpPostAsync<TEntrada>(TEntrada dadosEnvio, string uri)
        {
            var client = CriarHttpClient();
            var jsonCorpo = JsonConvert.SerializeObject(dadosEnvio);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonCorpo, Encoding.UTF8, "application/json"),
            };

            return await client.SendAsync(request);


            //_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");


            //response.EnsureSuccessStatusCode(); //

            //var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // if (response.StatusCode != statusCodeEsperado)
            // {
            //     Assert.Fail();
            // }


            // return responseBody;
        }
    }
}