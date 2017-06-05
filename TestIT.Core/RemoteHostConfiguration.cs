using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class RemoteHostConfiguration:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string OperationSystem { get; set; }
        public int Port { get; set; }
        public string HostName { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }
    }
}
