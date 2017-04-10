namespace TestIT.Entities
{
    public class TestRunFile : IEntityBase
    {
        public File File { get; set; }
        public int FileId { get; set; }
        public TestRun TestRun { get; set; }
        public int TestRunId { get; set; }
        public int Id { get; set; }
    }
}
