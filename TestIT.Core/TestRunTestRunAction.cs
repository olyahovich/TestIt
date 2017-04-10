using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class TestRunTestRunAction
    {
        public TestRunAction TestRunAction { get; set; }
        public TestRun TestRun { get; set; }
        public int TestRunActionId { get; set; }
        public int TestRunId { get; set; }
    }
}
