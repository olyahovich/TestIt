using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class TestRunRemoteHost : IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public TestRun TestRun { get; set; }
        public int TestRunId { get; set; }
        public RemoteHost RemoteHost { get; set; }
        public int RemoteHostId { get; set; }
    }
}
