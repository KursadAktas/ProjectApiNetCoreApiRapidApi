using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=KURSAD\\SQLEXPRESS; database=ApiDb; Trusted_Connection=true");
            
        }
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Staff> Staff => Set<Staff>();
        public DbSet<Subscribe> Subscribes => Set<Subscribe>();
        public DbSet<Testimonial> Testimonials => Set<Testimonial>();
        public DbSet<AboutUs> AboutUs => Set<AboutUs>();
        public DbSet<Booking> Bookings => Set<Booking>();
    }
}
