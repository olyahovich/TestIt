using System;

namespace TestIT.Entities
{
    public class TestRunResultFile:IEntityBase
    {
        public int Id { get; set; }
        public RemoteHost RemoteHost { get; set; }
        public int RemoteHostId { get; set; }
        public TestRunResult TestRunResult { get; set; }
        public int TestRunResultId { get; set; }
        public TestRunAction TestRunAction { get; set; }
        public int TestRunActionId { get; set; }
        public  File File { get; set; }
        public int FileId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
