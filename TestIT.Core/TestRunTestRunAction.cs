﻿using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class TestRunTestRunAction : IEntityBase
    {
        public TestRunAction TestRunAction { get; set; }
        public TestRun TestRun { get; set; }
        public int TestRunActionId { get; set; }
        public int TestRunId { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
    }
}