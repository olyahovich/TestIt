using System.Collections.Generic;

namespace TestIT.Entities
{
    public class Role : IEntityBase
    {
        public Role()
        {
            Permissions = new List<Permission>();
        }
        public ICollection<Permission> Permissions { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectType { get; set; }
        public int ProjectTypeId { get; set; }

    }
}
