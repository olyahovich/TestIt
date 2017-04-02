using System;
using System.Net;

namespace TestIT.Entities
{
    public class RemoteHost: IEntityBase
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public byte[] IpAddressBytes { get; set; }
        public IPAddress IpAddress
        {
            get { return new IPAddress(IpAddressBytes); }
            set { IpAddressBytes = value.GetAddressBytes(); }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
