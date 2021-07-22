using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HotFi.App.Clients
{
    public class AuthenticationHttpClient
    {
        private readonly HttpClient _client;

        public AuthenticationHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetTokenWithCode(string code)
        {
            var data = new Dictionary<string, string>();
            data.Add("client_id", "");
            var content = new FormUrlEncodedContent(data);
            var response = await _client.PostAsync("token", content);
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync(); 
            return token;
        }
    }
}