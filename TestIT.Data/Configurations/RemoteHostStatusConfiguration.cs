using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RemoteHostStatusConfiguration : EntityBaseConfiguration<RemoteHostStatus>
    {
        public RemoteHostStatusConfiguration(EntityTypeBuilder<RemoteHostStatus> builder)
        {

        }
    }
}