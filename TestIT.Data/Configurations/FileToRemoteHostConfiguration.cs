using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class FileToRemoteHostConfiguration : EntityBaseConfiguration<FileToRemoteHost>
    {
        public FileToRemoteHostConfiguration(EntityTypeBuilder<FileToRemoteHost> builder)
        {

        }
    }
}