using System;
using System.Net;

namespace TestIT.Entities
{
    public class RemoteHost: IEntityBase
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public User User { get; set; }
        public RemoteHostStatus RemoteHostStatus { get; set; }
        public int StatusId { get; set; }
        public RemoteHostConfiguration RemoteHostConfiguration { get; set; }
        public int ConfigurationId { get; set; }
    }
}
