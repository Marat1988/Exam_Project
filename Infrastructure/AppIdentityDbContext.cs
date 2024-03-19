using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("name=IdentityDb") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineOrder> LineOrders { get; set; }
        public DbSet<Recycler> Recyclers { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleAdmin = "Administrators";
            string roleUser = "Users";
            string userName = "Marat";
            string password = "mypassword";
            string email = "pirat03071988@mail.ru";

            roleMgr.Create(new AppRole(roleUser)); //Создаем роль пользователей
            roleMgr.Create(new AppRole(roleAdmin)); //Создаем роль админа

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleAdmin))
            {
                userMgr.AddToRole(user.Id, roleAdmin);
            }
        }
    }
}