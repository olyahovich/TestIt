using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestIT.Entities
{
    public class RemoteHostConfiguration:IEntityBase
    {
        public int Id { get; set; }
        public string OperationSystem { get; set; }
        public int Port { get; set; }
        public byte[] IpAddressBytes { get; set; }
        public IPAddress IpAddress
        {
            get { return new IPAddress(IpAddressBytes); }
            set { IpAddressBytes = value.GetAddressBytes(); }
        }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
