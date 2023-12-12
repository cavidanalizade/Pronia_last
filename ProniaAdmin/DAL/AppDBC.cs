
using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProniaAdmin.DAL
{
    public class AppDBC : IdentityDbContext<AppUser>
    {
        public AppDBC(DbContextOptions<AppDBC> options):base(options)
        {
            
        }

        public DbSet <Slider> sliders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Setting> Setting { get; set; }



    }
}
