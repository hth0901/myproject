using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "kdc",
                        UserName = "kdc",
                        Email = "kdc@email.com"
                    },
                    new AppUser
                    {
                        DisplayName = "host",
                        UserName = "host",
                        Email = "host@email.com"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Abc@12345");
                }
            }

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
