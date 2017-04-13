using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunRemoteHostConfiguration : EntityBaseConfiguration<TestRunRemoteHost>
    {
        public TestRunRemoteHostConfiguration(EntityTypeBuilder<TestRunRemoteHost> builder)
        {
            builder.Property(u => u.TestRunId).IsRequired();
            builder.Property(u => u.RemoteHostId).IsRequired();
        }
    }
}