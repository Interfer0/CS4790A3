using CS4790A3.Models;
using CS4790A3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SiteContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Sites.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User { userName = "Interfer0",
                            userEmail = "i@i.com",
                            Password = UserService.encryptPassword("num4"),
                            ConfirmPassword = UserService.encryptPassword("num4"),
                            accountType = 100

                },
                new User { userName = "Ralph",
                            userEmail = "i2@i.com",
                            Password = UserService.encryptPassword("num4"),
                            ConfirmPassword = UserService.encryptPassword("num4"),
                            accountType = 1 }

            };

            foreach (User d in users)
            {
                context.Users.Add(d);
            }
            context.SaveChanges();

            var sitelist = new Site[]
            {
                new Site {
                            siteName = "Home",
                            siteDescription = "Not really my house",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 41.145569731009495,
                            siteLong = -112.12646484375,
                            siteOffroad = false,
                            siteUses = "Living",
                            siteWater = true,
                            siteCost = 9.99,
                            siteAvailable = true

                           },
                new Site {
                            siteName = "Camp1",
                            siteDescription = "Not a real camp",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 42.145569731009495,
                            siteLong = -112.12646484375,
                            siteOffroad = false,
                            siteUses = "Nothing",
                            siteWater = true,
                            siteCost = 3.99,
                            siteAvailable = true
                           },
                new Site {
                            siteName = "Camp2",
                            siteDescription = "A field",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 38.856820134743607,
                            siteLong = -105.84228515625,
                            siteOffroad = false,
                            siteUses = "Swimming",
                            siteWater = true,
                            siteCost = 5.99,
                            siteAvailable = true
                           }

            };

            foreach (Site s in sitelist)
            {
                context.Sites.Add(s);
            }
            context.SaveChanges();





            
        }
    }
}

