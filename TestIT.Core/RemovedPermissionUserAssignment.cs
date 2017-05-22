using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class RemovedPermissionUserAssignment : IEntityBase
    {
        public UserAssignment UserAssignment { get; set; }
        public int UserAssignmentId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
