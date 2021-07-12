using System;
using System.Collections.Generic;

namespace HotFi.Library.Models
{
    public class DigitalOceanDroplet
    {
        private bool _archived { get; set; }

        public DigitalOceanDroplet()
        {
            CreatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string DropletId { get; set; }
        public string DropletName { get; set; }
        public string ImageSlug { get; set; }
        public string Region { get; set; }
        public string Size { get; set; }
        public string Domain { get; set; }
        public string UserData { get; set; }
        public string[] SshKeys { get; set; }
        public bool Backups { get; set; }
        public bool Ipv6 { get; set; }
        public bool PublicNetworking { get; set; }
        public string VpcUuid { get; set; }
        public bool Monitoring { get; set; }
        public string[] Volumes { get; set; }
        public string[] Tags { get; set; }
        
        
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
        public DateTime? ScriptsCompletedDate { get; set; }
        
        public virtual List<Application> Applications { get; set; }
    }
}