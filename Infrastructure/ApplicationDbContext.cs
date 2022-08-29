using Doman.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>()
                .HasMany(C => C.orderHs)
                .WithOne(O => O.Customer)
                .HasForeignKey(O => O.Cust_Id);

            builder.Entity<OrderH>()
                .HasMany(O => O.OrderD)
                .WithOne(D => D.OrderH)
                .HasForeignKey(O => O.Orderh_Id);

            builder.Entity<OrderD>()
                .HasOne(O => O.Item)
                .WithMany(I => I.OrderDs)
                .HasForeignKey(O => O.Item_Id);

            



         
        }
        public DbSet<Items> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderH> OrderH { get; set; }
        public DbSet<OrderD> OrderD { get; set; }


    }
}
