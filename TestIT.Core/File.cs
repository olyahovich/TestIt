using System;

namespace TestIT.Entities
{
    public class File : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NetworkPath { get; set; }
        public string Uri { get; set; }
        public string ContentType { get; set; }
        public string Verson { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public FileType FileType { get; set; }
        public int FileTypeID { get; set; }
    }
}
