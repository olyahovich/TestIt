using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class UserAssignment:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
