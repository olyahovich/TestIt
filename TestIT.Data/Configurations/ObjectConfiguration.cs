using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ObjectConfiguration : EntityBaseConfiguration<Object>
    {
        public ObjectConfiguration(EntityTypeBuilder<Object> builder)
        {

        }
    }
}