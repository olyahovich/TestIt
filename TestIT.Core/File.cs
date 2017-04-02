using System;

namespace TestIT.Entities
{
    public class File : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NetworkPath { get; set; }
        public string Uri { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        public string ContentType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
