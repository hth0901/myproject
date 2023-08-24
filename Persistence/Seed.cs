using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Activity.Any()) return;
            var activity = new List<Activity>
            {
                new Activity
                {
                    Title = "kdc",
                    Content = "kdc"
                },
                new Activity
                {
                    Title = "hth",
                    Content = "hth"
                }
            };

            await context.Activity.AddRangeAsync(activity);
            await context.SaveChangesAsync();
        }
    }
}
