using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaAdmin.DAL;

namespace ProniaAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 8;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(3);
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<AppDBC>().AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBC>(options =>
            options.UseSqlServer("server=DESKTOP-QQIUMB0;database=PraniaAdmin;Trusted_connection=true;Integrated security=true;encrypt=false"));

            var app = builder.Build();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}