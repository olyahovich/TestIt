﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunPhaseConfiguration : EntityBaseConfiguration<TestRunPhase>
    {
        public TestRunPhaseConfiguration(EntityTypeBuilder<TestRunPhase> builder)
        {
            builder.Property(u => u.TestResultId).IsRequired();
            builder.Property(u => u.TestRunId).IsRequired();
            builder.Property(u => u.Phase).IsRequired().HasMaxLength(255);
        }
    }
}