namespace PartyMate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    using Common;
    using PartyMate.Common;

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
                var location = new Location()
                {
                    Longitude = 23.3772423,
                    Latitude = 42.6508509
                };

                var locations = new DeletableEntityRepository<Location>(context);
                locations.Add(location);
                locations.SaveChanges();

                var club = new Club()
                {
                    ProfilePicUrl = "http://telerikacademy.com/Content/Images/news-img01.png",
                    Name = "TelerikAcademy",
                    Adress = @"бул. ""Александър Малинов"" 31, 1729 София",
                    Phone = "02 809 9897",
                    Location = location,
                    SiteUrl = "http://academy.telerik.com/",
                    FacebookUrl = "https://www.facebook.com/TelerikAcademy",
                    TwitterUrl = "https://twitter.com/TelerikAcademy",
                    Email = "",
                    Capacity = 2000,
                    ModeratorId = admin.Id
                };

                var review = new ClubReview()
                {
                    Club = club,
                    Content = "TEST TEST TEST TEST",
                    Rating = 5,
                    Author = admin
                };

                var reviews = new DeletableEntityRepository<ClubReview>(context);
                reviews.Add(review);
                var clubs = new DeletableEntityRepository<Club>(context);
                clubs.Add(club);

                var club2 = new Club()
                {
                    ProfilePicUrl = "http://yaltaclub.com/images/yalta-logo.png?1383083648",
                    Name = "Yalta Club",
                    Adress = @"20, Tsar Osvoboditel Blvd, Sofia 1000, Bulgaria",
                    Phone = "0897 870 230",
                    Location = location,
                    SiteUrl = "http://yaltaclub.com/",
                    FacebookUrl = "https://www.facebook.com/yaltaclub",
                    TwitterUrl = "",
                    Email = "",
                    Capacity = 4000,
                    ModeratorId = admin.Id
                };

                var review2 = new ClubReview()
                {
                    Club = club2,
                    Content = "TE ST TE ST TE ST",
                    Author = admin,
                    Rating = 4
                };

                reviews.Add(review2);

                clubs.Add(club2);

                clubs.SaveChanges();
            }
        }
    }
}
