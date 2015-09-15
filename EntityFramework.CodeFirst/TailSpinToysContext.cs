using System;
using System.Data.Entity;

namespace EntityFramework.CodeFirst
{
    internal class TailSpinToysContext : DbContext
    {
        public TailSpinToysContext()
            : base("Name=TailSpinToys")
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>().ToTable("Winkel");
            modelBuilder.Entity<Toy>().Property(toy => toy.Timestamp).IsRowVersion();
        }
    }
}