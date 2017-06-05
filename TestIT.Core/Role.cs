using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TestIT.Entities
{
    public class Role : IdentityRole 
    {
        public Role()
        {
            Permissions = new List<RolePermission>();
        }
        public ICollection<RolePermission> Permissions { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectType { get; set; }
        public int ProjectTypeId { get; set; }

    }
}
