using Newtonsoft.Json;

namespace HotFi.Library.ViewModel.Authentication
{
    public class AccessTokenDataModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}