using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Configurations;


namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.RegisterServices(builder.Configuration);

            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            builder.Services.AddDefaultIdentity<UserEntity>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.SignIn.RequireConfirmedAccount = false;
                x.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DataContext>();

            builder.Services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = "/auth/signin";
            });

            var app = builder.Build();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Home}/{id?}");

            app.Run();
        }
    }
}
