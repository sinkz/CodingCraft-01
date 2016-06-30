namespace CodingCraft01.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingCraft01.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodingCraft01.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrador"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrador" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Cliente"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Cliente" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@teste.com.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@teste.com.br", Email = "admin@teste.com.br", EmailConfirmed = true };

                manager.Create(user, "-Password1");
                manager.AddToRole(user.Id, "Administrador");
            }

            if (!context.Users.Any(u => u.UserName == "cliente@teste.com.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cliente@teste.com.br", Email = "cliente@teste.com.br", EmailConfirmed = true };

                manager.Create(user, "-Password2");
                manager.AddToRole(user.Id, "Cliente");
            }
        }
    }
}
