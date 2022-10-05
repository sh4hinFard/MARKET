using System;
using Be;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class db:DbContext
    {
        public DbSet<Kala> kalas { get; set; }
        public DbSet<Catogory> catogories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet <Details> Details { get; set; }
        public DbSet <kala_color> Kala_Color { get; set; }
        public DbSet<Kala_Size> Kala_Size { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Post> order_Posts { get; set; }
        public DbSet<Ostan> ostans { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Pardakht> pardakhts { get; set; }
        public DbSet<TypeOfPay> typeOfPays { get; set; }
        public DbSet<User>users{ get; set; }
        public DbSet<Roles> UserRoles  { get; set; }
        public DbSet<Wallet> wallets { get; set; }
        public DbSet<WalletType> walletTypes { get; set; }







        public db()
       
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=fard;User ID=fard1;Password=123");
        }
    }
}
