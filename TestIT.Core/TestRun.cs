using System;
using System.Collections.Generic;

namespace TestIT.Entities
{
    public class TestRun:IEntityBase
    {
        public TestRun()
        {
            TestRunRemoteHosts = new List<TestRunRemoteHost>();
            TestRunActions = new List<TestRunTestRunAction>();
        }
        public ICollection<TestRunTestRunAction> TestRunActions { get; set; }
        public ICollection<TestRunRemoteHost> TestRunRemoteHosts { get; set; }
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int CompletedBy { get; set; }
        public int AssignedTo { get; set; }
        public User User { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TestRunStatus TestRunStatus { get; set; }
        public int TestRunStatusId { get; set; }
        public TestRunResult TestRunResult { get; set; }
        public int TestRunResultId { get; set; }
    }
}