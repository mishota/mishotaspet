using System.Web;
using System.Data;
using System.Data.Entity;
using MishPets.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
namespace MishPets.Helpers
{
    public class IdentityDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            // создаем роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "over" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "ksu_a@mail.ru", UserName = "ksu_a@mail.ru" };
            string password = "jrcfy84";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            base.Seed(context);


            //var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //IdentityResult createUserResult = null;
            //IdentityResult createRoleResult = null;
            //var user = userManager.FindByName("ksu_a@mail.ru "); if (user == null)
            //{
            //    user = new ApplicationUser { Email = "ksu_a@mail.ru", UserName = "ksu_a@mail.ru" };
            //    var pass = "jrcfy84"; createUserResult = userManager.Create(user, pass);
            //}
            //var role = roleManager.FindByName("admin");
            //if (role == null)
            //{
            //    role = new IdentityRole { Name = "admin" };
            //    createRoleResult = roleManager.Create(role);
            //}

            //var role1 = roleManager.FindByName("over");
            //if (role1 == null)
            //{
            //    role1 = new IdentityRole { Name = "over" };
            //    createRoleResult = roleManager.Create(role);
            //}
            //if (createUserResult != null && createUserResult.Succeeded)
            //    if (createRoleResult.Succeeded)
            //        userManager.AddToRole(user.Id.ToString(), "admin");
            //role = roleManager.FindByName("user");
            //if (role == null)
            //{
            //    roleManager.Create(new IdentityRole { Name = "user" });
            //}

        }
    }
}