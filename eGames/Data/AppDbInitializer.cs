using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Identity;

namespace eGames.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                dbContext.Database.EnsureCreated();

                // Platforms
                if (!dbContext.Platforms.Any())
                {
                    dbContext.Platforms.AddRange(new List<Platform>()
                    {
                        new Platform()
                        {
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/Steam_icon_logo.svg/2048px-Steam_icon_logo.svg.png",
                            Name = "Steam",
                            URL = "https://store.steampowered.com/",
                            Description = "Steam is a video game digital distribution service and storefront by Valve." +
                                          " It was launched as a software client in September 2003 as a way for Valve to " +
                                          "provide automatic updates for their games, and expanded to distributing and offering" +
                                          " third-party game publishers' titles in late 2005."
                        },
                        new Platform()
                        {
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Epic_Games_logo.svg/1764px-Epic_Games_logo.svg.png",
                            Name = "Epic Games",
                            URL = "https://www.epicgames.com/",
                            Description = "Epic Games, Inc. is an American video game and software developer and publisher " +
                                          "based in Cary, North Carolina. The company was founded by Tim Sweeney as Potomac " +
                                          "Computer Systems in 1991, originally located in his parents' house in Potomac, Maryland."
                        },
                        new Platform()
                        {
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Ubisoft_logo.svg/2238px-Ubisoft_logo.svg.png",
                            Name = "Ubisoft",
                            URL = "http://ubisoft.com/",
                            Description = "Ubisoft Entertainment SA is a French video game publisher headquartered in Saint-Mandé" +
                                          " with development studios across the world."
                        }
                    });
                    dbContext.SaveChanges();
                }
                // Publishers
                if (!dbContext.Publishers.Any())
                {
                    dbContext.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            Logo = "https://avatars.cloudflare.steamstatic.com/751c4faad6133699315ca7d4ae03293cd3abbe49_full.jpg",
                            Name = "Activision",
                            Description = "Activision Publishing, Inc. is an American video game publisher based in Santa Monica, California."
                        },
                        new Publisher()
                        {
                            Logo = "https://avatars.akamai.steamstatic.com/40a85b52747a78b26e393e3f9e58f319194b1b33_full.jpg",
                            Name = "PlayStation Studios™",
                            Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding " +
                                          "and immersive games, including some of the most popular and critically acclaimed titles in entertainment history."
                        },
                        new Publisher()
                        {
                            Logo = "https://avatars.cloudflare.steamstatic.com/618cc2a46fad78ed1259df505c2de5bb4d806532_full.jpg",
                            Name = "Electronic Arts",
                            Description = "Electronic Arts Inc. is an American video game company headquartered in Redwood City, California."
                        }
                    });
                    dbContext.SaveChanges();
                }
                // Developers
                if (!dbContext.Developers.Any())
                {
                    dbContext.Developers.AddRange(new List<Developer>
                    {
                        new Developer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1d/Infinity_Ward.svg/2560px-Infinity_Ward.svg.png",
                            FullName = "Infinity Ward",
                            Biography = "Infinity Ward, Inc. is an American video game developer."
                        },
                        new Developer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/en/c/c7/RavenSoftwareLogo.png",
                            FullName = "Raven Software",
                            Biography = "Raven Software Corporation is an American video game developer based in Wisconsin and founded in 1990."
                        },
                        new Developer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d4/Ghost_Games_Logo.svg/2048px-Ghost_Games_Logo.svg.png",
                            FullName = "Ghost Games",
                            Biography = "Ghost Games is a Swedish video game developer owned by Electronic Arts (EA) and located in Gothenburg."
                        },
                        new Developer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Insomniac_Games_logo.svg/2560px-Insomniac_Games_logo.svg.png",
                            FullName = "Insomniac Games",
                            Biography = "Insomniac Games, Inc. is an American video game developer based in Burbank, California and a studio of PlayStation Studios."
                        }
                    });
                    dbContext.SaveChanges();
                }
                // Games
                if (!dbContext.Games.Any())
                {
                    dbContext.Games.AddRange(new List<Game>
                    {
                        new Game()
                        {
                            ImageURL = "https://assets-prd.ignimgs.com/2022/05/24/call-of-duty-modern-warfare-2-button-02-1653417394041.jpg",
                            Name = "Call of Duty®: Modern Warfare® II",
                            Description = "Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the " +
                                          "return of the iconic Operators of Task Force 141.",
                            Price = 59.99,
                            ReleaseDate = new DateTime(2022,10,27),
                            Category = Enums.GameCategory.Action,
                            PlatformId = 1,
                            PublisherId = 1
                        },
                        new Game()
                        {
                            ImageURL = "https://assets1.ignimgs.com/2019/08/14/nfs-heat---button-fin-1565806445973.jpg",
                            Name = "Need for Speed™ Heat",
                            Description = "Hustle by day and risk it all at night in Need for Speed™ Heat Deluxe Edition, a white-knuckle street" +
                                          " racer, where the lines of the law fade as the sun starts to set.",
                            Price = 69.99,
                            ReleaseDate = new DateTime(2019,11,8),
                            Category = Enums.GameCategory.Racing,
                            PlatformId = 1,
                            PublisherId = 3
                        },
                        new Game()
                        {
                            ImageURL = "https://assets-prd.ignimgs.com/2022/06/03/spideyremastered-1654220581626.jpg",
                            Name = "Marvel’s Spider-Man Remastered",
                            Description = "In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original action-packed story.",
                            Price = 59.99,
                            ReleaseDate = new DateTime(2022,8,12),
                            Category = Enums.GameCategory.Action,
                            PlatformId = 2,
                            PublisherId = 2
                        }
                    });
                    dbContext.SaveChanges();
                }
                // Developers & Games
                if (!dbContext.Developers_Games.Any())
                {
                    dbContext.Developers_Games.AddRange(new List<Developer_Game>
                    {
                        new Developer_Game()
                        {
                            DeveloperId = 1,
                            GameId = 1
                        },
                        new Developer_Game()
                        {
                            DeveloperId = 2,
                            GameId = 1
                        },
                        new Developer_Game()
                        {
                            DeveloperId = 3,
                            GameId = 2
                        },
                        new Developer_Game()
                        {
                            DeveloperId = 4,
                            GameId = 3
                        }
                    });
                    dbContext.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Admin user
                const string adminEmail = "admin@egames.com";
                const string adminPassword = "admin@123$";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true,
                    };
                    // User, Password
                    await userManager.CreateAsync(newAdminUser, adminPassword);
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                // Normal user
                const string userEmail = "user@egames.com";
                const string userPassword = "admin@123$";

                var user = await userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        FullName = "App User",
                        UserName = "app-user",
                        Email = userEmail,
                        EmailConfirmed = true,
                    };
                    // User, Password
                    await userManager.CreateAsync(user, userPassword);
                    await userManager.AddToRoleAsync(user, UserRoles.User);
                }
            }
        }
    }
}