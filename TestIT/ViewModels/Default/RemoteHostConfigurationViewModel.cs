using System;

namespace TestIT.Web.ViewModels.Default
{
    public class RemoteHostConfigurationViewModel
    {
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
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }
        internal bool IsModelValid()
        {
            throw new NotImplementedException();
        }
    }
}
