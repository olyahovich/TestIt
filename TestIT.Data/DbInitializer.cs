using System.Linq;
using TestIT.Entities;

namespace TestIT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TestITContext context)
        {
            context.Database.EnsureCreated();

            // Look for any test data.
            if (context.TestDatas.Any())
            {
                return;   // DB has been seeded
            }

            context.SaveChanges();
        }
    }
}
