namespace TestIT.Entities
{
    public class FileToRemoteHost : IEntityBase
    {
        public int Id { get; set; }
        public File File { get; set; }
        public int FileId { get; set; }
        public RemoteHost RemoteHost { get; set; }
        public int RemoteHostId { get; set; }
    }
}
