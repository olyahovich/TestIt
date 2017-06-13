using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestIT.Entities;
namespace TestIT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TestItContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
