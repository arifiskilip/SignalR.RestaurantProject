using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Repositories.Contexts
{
    public class RestaurantContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
