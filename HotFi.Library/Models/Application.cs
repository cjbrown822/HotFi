using System;

namespace HotFi.Library.Models
{
    public class Application
    {
        private bool _archived { get; set; }
        
        public Application()
        {
            CreatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ApplicationName { get; set; }
        public string Domain { get; set; }
        public string GitHubUrl { get; set; }
        public int PortNumber { get; set; }
        public bool Active { get; set; }

        public bool Archived
        {
            get => _archived;
            set
            {
                _archived = value;
                if (_archived) ArchivedDate = DateTime.Now;
                else ArchivedDate = null;
            }
        }

        public DateTime? CreatedDate { get; private set; }
        public DateTime? ArchivedDate { get; private set; }
        
        public virtual ApplicationUser User { get; set; }
    }
}