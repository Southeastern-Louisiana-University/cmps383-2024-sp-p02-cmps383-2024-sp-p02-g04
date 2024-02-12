namespace Selu383.SP24.Api.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Selu383.SP24.Api.Features.Hotels;
        public class SeedHelper

        {
            public static async Task MigrateAndSeed(IServiceProvider serviceProvider)


            {

                var dataContext = serviceProvider.GetRequiredService<DataContext>();

                await dataContext.Database.MigrateAsync();

            await AddUsers(serviceProvider);

            await AddRoles(serviceProvider);

                var hotels = dataContext.Set<Hotel>();

                if (!await hotels.AnyAsync())

                {
                    for (int i = 0; i < 6; i++)

                    {

                        dataContext.Set<Hotel>()
                            .Add(new Hotel

                            {

                                Name = "Hilton of Covington" + i,
                                Address = "2983 Hwy 21, Covington La 70433",

                            });

                    }

                    await dataContext.SaveChangesAsync();
                }

            }

            private static async Task AddUsers(IServiceProvider serviceProvider)

            {
                const string defaultPass = "Password123!";
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

                if (userManager.Users.Any())
                {
                    return;
                }

                var adminUser = new User
                {
                    UserName = "galkadi",
                };

                var result = await userManager.CreateAsync(adminUser, defaultPass);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin);
                }
                var bob = new User
                {
                    UserName = "bob",
                };

                await userManager.CreateAsync(bob, defaultPass);
                await userManager.AddToRoleAsync(bob, Roles.User);

                var sue = new User
                {
                    UserName = "sue",
                };

                await userManager.CreateAsync(sue, defaultPass);
                await userManager.AddToRoleAsync(sue, Roles.User);

            }

            private static async Task AddRoles(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
                if (roleManager.Roles.Any())
                {
                    return;
                }

            await roleManager.CreateAsync(new Role

            {

                Name = Roles.User,

            });

            await roleManager.CreateAsync(new Role
                {

                    Name = Roles.Admin,

                });

            }
        }
    }