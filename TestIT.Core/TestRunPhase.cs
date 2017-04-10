namespace TestIT.Entities
{
    public class TestRunPhase:IEntityBase
    {
        public int Id { get; set; }
        public string Phase { get; set;}
        public TestRun TestRun { get; set; }
        public TestRunResult TestRunResult { get; set; }
        public int TestRunId { get; set; }
        public int TestResultId { get; set; }
    }
}
