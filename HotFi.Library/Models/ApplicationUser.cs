using System.Collections.Generic;

namespace HotFi.Library.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }                     
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public bool Archived { get; set; }
        public bool CanContact { get; set; }
        
        public virtual List<Application> Applications { get; set; }
    }
}