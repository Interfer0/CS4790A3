using CS4790A3.Models;
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
                new User { userName = "Phillip",
                            userEmail = "i@i.com" },
                new User { userName = "Ralph",
                            userEmail = "i2@i.com" }

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
                            UserID = users.Single( i => i.UserID == 1).UserID,
                            siteDescription = "Not really my house",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 41.145569731009495,
                            siteLong = -112.12646484375,
                            siteOffroad = false,
                            siteUses = "Living",
                            siteWater = true,
                            
                           },
                new Site {
                            siteName = "Camp1",
                            UserID = users.Single( i => i.UserID == 1).UserID,
                            siteDescription = "Not a real camp",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 42.145569731009495,
                            siteLong = -112.12646484375,
                            siteOffroad = false,
                            siteUses = "Nothing",
                            siteWater = true
                           },
                new Site {
                            siteName = "Camp2",
                            UserID = users.Single( i => i.UserID == 2).UserID,
                            siteDescription = "A field",
                            siteGas = 3,
                            siteLandType = "Private",
                            siteLevel = false,
                            siteLat = 38.856820134743607,
                            siteLong = -105.84228515625,
                            siteOffroad = false,
                            siteUses = "Swimming",
                            siteWater = true
                           }

            };

            foreach (Site s in sitelist)
            {
                context.Sites.Add(s);
            }
            context.SaveChanges();




            

            


            var comments = new Comment[]
            {
                new Comment {UserID = 2, cmtComment = "Terrible Site"
                },
                new Comment {UserID = 2, cmtComment = "Wonderful Site"
                }
            };

            foreach (Comment c in comments)
            {
                context.Comments.Add(c);
            }
            context.SaveChanges();
            
        }
    }
}

