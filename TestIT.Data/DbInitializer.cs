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

            var testData = new TestData
            {
                Username = "JaneDoe",
                EmailAddress = "jane.doe@example.com",
                Password = "LetM@In!",
                Currency = 321.45M
            };

            context.TestDatas.Add(testData);
            context.SaveChanges();
        }
    }
}
