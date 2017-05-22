using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class User : IEntityBase
    {
        public User()
        {
            UserAssignments = new List<UserAssignment>();
        }

        public ICollection<UserAssignment> UserAssignments { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string FullName => LastName + ", " + FirstName;
    }
}
