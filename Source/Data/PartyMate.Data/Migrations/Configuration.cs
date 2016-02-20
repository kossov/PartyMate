namespace PartyMate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

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
            }
        }
    }
}
