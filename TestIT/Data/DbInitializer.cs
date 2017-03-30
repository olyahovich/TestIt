﻿using System.Linq;
using TestIT.ViewModels;

namespace TestIT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TestITContext context)
        {
            context.Database.EnsureCreated();

            // Look for any test data.
            if (context.TestData.Any())
            {
                return;   // DB has been seeded
            }

            var testData = new TestData
            {
                Username = "JaneDoe",
                EmailAddress = "jane.doe@example.com",
                Password = "LetM@In!",
                Currency = 321.45M
            };

            context.TestData.Add(testData);
            context.SaveChanges();
        }
    }
}
