using Newtonsoft.Json;

namespace HotFi.Library.ViewModel.Authentication
{
    public class IntrospectDataModel
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
        [JsonProperty("aud")]
        public string Audience { get; set; }
        [JsonProperty("authenticationType")]
        public string AuthenticationType { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }
        [JsonProperty("exp")]
        public long? Expiration { get; set; }
        [JsonProperty("iat")]
        public long? IssuedAt { get; set; }
        [JsonProperty("iss")]
        public string Issued { get; set; }
        [JsonProperty("preferred_username")]
        public string PreferredUsername { get; set; }
        [JsonProperty("roles")]
        public string[] Roles { get; set; }
        [JsonProperty("sub")]
        public string Subject { get; set; }
    }
}