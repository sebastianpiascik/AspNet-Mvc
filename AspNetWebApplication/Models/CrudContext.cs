using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetWebApplication.Models
{
    public class CrudContext : DbContext
    {

        public CrudContext() : base("AspNetConnection")
        {

        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Bike>()
                .HasRequired<Category>(s => s.CurrentCategory)
                .WithMany(g => g.Bikes)
                .HasForeignKey<int>(s => s.CurrentCategoryId);
        }
    }
}