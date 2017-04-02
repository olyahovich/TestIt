using System;
using System.Collections.Generic;

namespace TestIT.Entities
{
    public class Project : IEntityBase
    {
        public Project()
        {
            Files = new List<File>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
