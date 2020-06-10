using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut13.Entities
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Confectionery_Order> ConfectioneryOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CustomerDbContext() { }
        public CustomerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Customer */
            modelBuilder.Entity<Customer>(entity => 
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(60);

                entity
                    .HasMany(e => e.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.IdClient)
                    .IsRequired();

                entity.ToTable("Customer");
            });

            /* Employee */
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.IdEmployee).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(60);

                entity
                    .HasMany(e => e.Orders)
                    .WithOne(o => o.Employee)
                    .HasForeignKey(o => o.IdClient)
                    .IsRequired();

                entity.ToTable("Employee");
            });

            /* Order */
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();

                entity.Property(e => e.DateAccepted)
                    .IsRequired();

                entity.Property(e => e.DateFinished)
                    .IsRequired();

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdClient).IsRequired();
                entity.Property(e => e.IdEmployee).IsRequired();

                entity
                    .HasMany(e => e.Confectionery_Orders)
                    .WithOne(co => co.Order)
                    .HasForeignKey(co => co.IdOrder)
                    .IsRequired();

                entity.ToTable("Order");
            });

            /* Confectionery */
            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfectionery);
                entity.Property(e => e.IdConfectionery).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(e => e.PricePerItem)
                    .IsRequired();

                entity.Property(e => e.Type)
                    .HasMaxLength(40)
                    .IsRequired();

                entity
                    .HasMany(e => e.Confectionery_Orders)
                    .WithOne(co => co.Confectionery)
                    .HasForeignKey(co => co.IdConfectionery)
                    .IsRequired();

                entity.ToTable("Confectionery");
            });

            /* Confectionery_Order */
            modelBuilder.Entity<Confectionery_Order>(entity =>
            {
                entity.HasKey(e => new { e.IdConfectionery, e.IdOrder });

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdConfectionery).IsRequired();
                entity.Property(e => e.IdOrder).IsRequired();

                entity.ToTable("Confectionery_Order");
            });
        }
    }
}
