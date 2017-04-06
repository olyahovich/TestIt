using System;

namespace TestIT.Entities
{
    public class RoleUserAssignment : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
