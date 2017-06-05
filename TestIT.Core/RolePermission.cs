using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class RolePermission : IEntityBase
    {
        public int PermissionId { get; set; }
        public string RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
