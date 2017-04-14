﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class UserAssignmentConfiguration : EntityBaseConfiguration<UserAssignment>
    {
        public new void Configure(EntityTypeBuilder<UserAssignment> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ProjectId).IsRequired();
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}