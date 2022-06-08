using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SHOP.DBModel
{
    public partial class ShopDB : DbContext
    {
        public ShopDB()
            : base("name=ShopDB")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Importance> Importance { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Surname)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronymic)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.PaymentType)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Importance>()
                .HasMany(e => e.Note)
                .WithRequired(e => e.Importance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.PaymentType)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentType>()
                .Property(e => e.BankName)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.DirectorName)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);
        }
    }
}
