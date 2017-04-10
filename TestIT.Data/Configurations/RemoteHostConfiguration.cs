using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;
using Object = TestIT.Entities.Object;

namespace TestIT.Data.Configurations
{
    public class RemoteHostConfiguration : EntityBaseConfiguration<RemoteHost>
    {
        public RemoteHostConfiguration(EntityTypeBuilder<RemoteHost> builder)
        {

        }
    }
}
