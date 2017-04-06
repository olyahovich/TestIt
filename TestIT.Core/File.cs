using System;

namespace TestIT.Entities
{
    public class File : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NetworkPath { get; set; }
        public string Uri { get; set; }
        public virtual TestRun TestRun { get; set; }
        public int TestRunId { get; set; }
        public string ContentType { get; set; }
        public string Verson { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
