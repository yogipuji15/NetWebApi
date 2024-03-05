using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using NetWebApi.Models.Entity;

namespace NetWebApi.Helper
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DBConnection>());
            }
        }

        private static void SeedData(DBConnection context)
        {
            if (!context.Users.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Users.AddRange(
                    new User() { Name = "Yogi", Email = "yogi@gmail.com", Password = "********" },
                    new User() { Name = "John", Email = "john@gmail.com", Password = "********" },
                    new User() { Name = "David", Email = "david@gmail.com", Password = "*********" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
