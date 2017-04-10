using System;

namespace TestIT.Entities
{
    public class RolePermission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
