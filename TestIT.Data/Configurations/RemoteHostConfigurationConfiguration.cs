using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestIT.Data.Configurations
{
    public class RemoteHostConfigurationConfiguration : EntityBaseConfiguration<Entities.RemoteHostConfiguration>
    {
        public RemoteHostConfigurationConfiguration(EntityTypeBuilder<Entities.RemoteHostConfiguration> builder)
        {

        }
    }
}