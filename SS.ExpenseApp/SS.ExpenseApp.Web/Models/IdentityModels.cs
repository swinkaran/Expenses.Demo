using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SS.ExpenseApp.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ExpenseEntities", throwIfV1Schema: false)
        {
            Database.SetInitializer(new IdentityDataSeeder());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class IdentityDataSeeder : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            // Seed demo Roles
            var rs = new RoleStore<IdentityRole>(context);
            var rm = new RoleManager<IdentityRole>(rs);

            rm.Create(new IdentityRole { Id = "1", Name = "Employee" });
            rm.Create(new IdentityRole { Id = "2", Name = "Manager" });
            rm.Create(new IdentityRole { Id = "3", Name = "Finance" });

            // Seed udemo Users
            var us = new UserStore<ApplicationUser>(context);
            var um = new UserManager<ApplicationUser>(us);

            string password = um.PasswordHasher.HashPassword("Password_1");

            um.Create(new ApplicationUser { Id = "1", UserName = "employee1@gmail.com", Email = "employee1@gmail.com", PasswordHash= password });
            um.Create(new ApplicationUser { Id = "2", UserName = "employee2@gmail.com", Email = "employee2@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "3", UserName = "employee3@gmail.com", Email = "employee3@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "4", UserName = "employee4@gmail.com", Email = "employee4@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "5", UserName = "manager1@gmail.com", Email = "manager1@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "6", UserName = "manager2@gmail.com", Email = "manager2@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "7", UserName = "finance1@gmail.com", Email = "finance1@gmail.com", PasswordHash = password });
            um.Create(new ApplicationUser { Id = "8", UserName = "finance2@gmail.com", Email = "finance2@gmail.com", PasswordHash = password });


            // Seed User to Role
            um.AddToRole("1", "Employee");
            um.AddToRole("2", "Employee");
            um.AddToRole("3", "Employee");
            um.AddToRole("4", "Employee");
            um.AddToRole("5", "Manager");
            um.AddToRole("6", "Manager");
            um.AddToRole("7", "Finance");
            um.AddToRole("8", "Finance");

        }
    }

}