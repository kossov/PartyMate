namespace PartyMate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    using PartyMate.Common;
    using Common;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                // Create Admin role
                var adminRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(adminRole);

                // Create User role
                var userRole = new IdentityRole { Name = GlobalConstants.UserRoleName };
                roleManager.Create(userRole);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var admin = new User
                {
                    FirstName = GlobalConstants.AdministratorFirstName,
                    LastName = GlobalConstants.AdministratorLastName,
                    UserName = GlobalConstants.AdministratorUserName,
                    Email = GlobalConstants.AdministratorUserName
                };

                userManager.Create(admin, GlobalConstants.AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

                // Add TelerikAcademy for Demo Purposes
                var db = new ApplicationDbContext();
                var location = new Location()
                {
                    Longitude = 23.3772423,
                    Latitude = 42.6508509
                };

                var locations = new DeletableEntityRepository<Location>(db);
                locations.Add(location);
                locations.SaveChanges();

                var club = new Club()
                {
                    ProfilePicUrl = "http://telerikacademy.com/Content/Images/news-img01.png",
                    Name = "TelerikAcademy",
                    Adress = @"бул. ""Александър Малинов"" 31, 1729 София",
                    Phone = "02 809 9897",
                    Location = location,
                    SiteUrl = "http://telerikacademy.com/",
                    FacebookUrl = "https://www.facebook.com/TelerikAcademy",
                    TwitterUrl = "https://twitter.com/TelerikAcademy",
                    Email = "Zdravko.Georgiev@telerik.com",
                    Capacity = 5000,
                    ModeratorId = admin.Id
                };

                var clubs = new DeletableEntityRepository<Club>(db);
                clubs.Add(club);
                clubs.SaveChanges();
            }
        }
    }
}
