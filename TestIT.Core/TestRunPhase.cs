﻿using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class TestRunPhase:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Phase { get; set;}
        public TestRun TestRun { get; set; }
        public TestRunResult TestRunResult { get; set; }
        public int TestRunId { get; set; }
        public int TestResultId { get; set; }
    }
}