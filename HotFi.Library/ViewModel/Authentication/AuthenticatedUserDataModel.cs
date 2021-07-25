using Newtonsoft.Json;

namespace HotFi.Library.ViewModel.Authentication
{
    public class AuthenticatedUserDataModel
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("email_verified")]
        public string EmailVerified { get; set; }
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("picture")]
        public string PictureUrl { get; set; }
        [JsonProperty("roles")]
        public string[] Roles { get; set; }
        [JsonProperty("sub")]
        public string Subject { get; set; }
    }
}