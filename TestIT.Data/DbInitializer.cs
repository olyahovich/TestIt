using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestIT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TestItContext context)
        {
            context.Database.Migrate();
        }
    }
}
