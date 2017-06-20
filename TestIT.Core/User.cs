using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

 namespace TestIT.Entities
{ 
        // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public User()
        {
            UserAssignments = new List<UserAssignment>();
        }

        public ICollection<UserAssignment> UserAssignments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string FullName { get; set; }
    }
}
