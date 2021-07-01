using System;

namespace HotFi.Library.Models
{
    public class ServerInformation
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string UserSshVaultKey { get; set; }
        
        public string ApplicationUsername { get; set; }
        public string ApplicationSshVaultKey { get; set; }
        
        public string ApplicationServiceName { get; set; }
        
        public string DropletId { get; set; }
        public virtual Droplet Droplet { get; set; }
    }
}