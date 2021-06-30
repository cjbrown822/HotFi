using System.Collections.Generic;

namespace HotFi.Library.Models
{
    public class Droplet
    {
        public string Id { get; set; }
        public string DropletId { get; set; }
        public string DropletName { get; set; }
        
        public virtual List<Application> Applications { get; set; }
    }
}