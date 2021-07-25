using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HotFi.Library.ViewModel.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Renci.SshNet.Messages.Authentication;

namespace HotFi.App.Clients
{
    public class AuthenticationHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly string _clientId;
        private readonly string _authUrl;
        private readonly string _clientSecret;
        private readonly string _redirectUri;

        public AuthenticationHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            _clientId = _configuration.GetSection("Auth").GetSection("ClientId").Value;
            _clientSecret = _configuration.GetSection("Auth").GetSection("ClientSecret").Value;
            _authUrl = _configuration.GetSection("Auth").GetSection("AuthAddress").Value;
            _redirectUri = _configuration.GetSection("Auth").GetSection("RedirectUrl").Value;
        }

        public async Task<AccessTokenDataModel> GetTokenWithCode(string code)
        {
            var contentData = new Dictionary<string, string>();
            contentData.Add("client_id", _clientId);
            contentData.Add("client_secret", _clientSecret);
            contentData.Add("code", code);
            contentData.Add("grant_type", "authorization_code");
            contentData.Add("redirect_uri", _redirectUri);
            var content = new FormUrlEncodedContent(contentData);
            var response = await _client.PostAsync("oauth2/token", content);
            response.EnsureSuccessStatusCode();
            var token = JsonConvert.DeserializeObject<AccessTokenDataModel>( await response.Content.ReadAsStringAsync()); 
            return token;
        }

        public async Task<IntrospectDataModel> IntrospectToken(string token)
        {
            var data = new Dictionary<string, string>();
            data.Add("token", token);
            data.Add("client_id", _clientId);
            var content = new FormUrlEncodedContent(data);
            var response = await _client.PostAsync("oauth2/introspect", content);
            response.EnsureSuccessStatusCode();
            var info = JsonConvert.DeserializeObject<IntrospectDataModel>(await response.Content.ReadAsStringAsync()); 
            return info;
        }

        public async Task<AuthenticatedUserDataModel> UserInfo(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync("oauth2/userinfo");
            response.EnsureSuccessStatusCode();
            var userInfo =
                JsonConvert.DeserializeObject<AuthenticatedUserDataModel>(await response.Content.ReadAsStringAsync());
            return userInfo;
        }
    }
}