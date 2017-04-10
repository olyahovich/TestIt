using System;

namespace TestIT.Entities
{
    class RemovedPermissionUserAssignment
    {
        public UserAssignment UserAssignment { get; set; }
        public int UserAssignmentId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
