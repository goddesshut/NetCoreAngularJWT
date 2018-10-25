using Models;
using Models.Enums;
using Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public static class AuthDbContextExtensions
    {
        public static void Seed(this AuthDbContext context)
        {
            SeedProfile(context);
            context.SaveChanges();
        }

        static void SeedProfile(AuthDbContext context)
        {
            var hash = new Hash();

            var profileModel = new Profile {
                Username = "admin",
                Password = hash.Create("admin"),
                Firstname = "Administrator",
                Lastname = "System",
                EMail = "administrator@administrator.com",
                EProfile = EProfile.Employee,
                IsActive = true
            };

            context.Profile.Add(profileModel);
        }

    }
}
