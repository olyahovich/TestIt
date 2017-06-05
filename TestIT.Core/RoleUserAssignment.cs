using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class RoleUserAssignment : IEntityBase
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
