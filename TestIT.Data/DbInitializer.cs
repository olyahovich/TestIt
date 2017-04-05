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

            context.TestData.Add(testData);
            context.SaveChanges();
        }
    }
}
