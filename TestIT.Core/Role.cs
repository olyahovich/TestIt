﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Role : IEntityBase
    {
        public Role()
        {
            Permissions = new List<RolePermission>();
        }
        public ICollection<RolePermission> Permissions { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectType { get; set; }
        public int ProjectTypeId { get; set; }

    }
}
