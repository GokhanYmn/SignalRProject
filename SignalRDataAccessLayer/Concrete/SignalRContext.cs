using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        public SignalRContext(DbContextOptions<SignalRContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
    }

}




