using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class UtilitarioTest
    {
        public static WebApplicationFactory<Program> ObterWebApplication() =>
            new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { }); });

        public static HttpClient CriarHttpClient() => ObterWebApplication().CreateClient();

        public static async Task<HttpResponseMessage> HttpPostAsync<Entrada>(Entrada dadosEnvio, string uri,
            HttpStatusCode statusCodeEsperado)
        {
            var _Client = CriarHttpClient();
            var jsonCorpo = JsonConvert.SerializeObject(dadosEnvio);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonCorpo, Encoding.UTF8, "application/json"),
            };

            return await _Client.SendAsync(request);


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