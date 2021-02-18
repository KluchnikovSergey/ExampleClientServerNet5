using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class StorageDBContext : DbContext
    {
        public StorageDBContext(DbContextOptions<StorageDBContext> options): base(options)
        { 

        }

        public virtual DbSet<Entity.Product> Products { get; set; }
        public virtual DbSet<Entity.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne<Entity.Category>(product => product.Category)
                    .WithMany(category => category.Products)
                    .HasForeignKey(product => product.Id);
            });

            modelBuilder.Entity<Entity.Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(category => category.parentCategory)
                    .WithMany(category => category.Categories)
                    .HasForeignKey(category => category.Id);

                entity.HasMany<Entity.Category>(category => category.Categories)
                    .WithOne(category => category.parentCategory)
                    .HasForeignKey(category => category.ParentCategoryId);


                entity.HasMany<Entity.Product>(category => category.Products)
                    .WithOne(product => product.Category)
                    .HasForeignKey(product => product.ParentCategoryId);
            });            
        }        
    }
}
