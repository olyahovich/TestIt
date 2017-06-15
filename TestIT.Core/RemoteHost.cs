using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class RemoteHost: IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string HostName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }
        public User User { get; set; }
        public RemoteHostStatus RemoteHostStatus { get; set; }
        public int RemoteHostStatusId { get; set; }
        public RemoteHostConfiguration RemoteHostConfiguration { get; set; }
        public int RemoteHostConfigurationId { get; set; }
    }
}
