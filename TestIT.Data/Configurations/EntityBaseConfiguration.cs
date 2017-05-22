using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class EntityBaseConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class, IEntityBase
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}