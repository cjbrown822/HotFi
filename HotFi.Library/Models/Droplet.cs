using System;
using System.Collections.Generic;

namespace HotFi.Library.Models
{
    public class Droplet
    {
        private bool _archived { get; set; }

        public Droplet()
        {
            CreatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string DropletId { get; set; }
        public string DropletName { get; set; }
        
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
        
        public virtual List<Application> Applications { get; set; }
    }
}