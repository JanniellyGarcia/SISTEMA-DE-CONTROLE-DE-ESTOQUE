using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        // Declara as entidades

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Inventory> Inventories { get; set; }


        //Mapeia as entidades:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure); // Mapeamento de User
            modelBuilder.Entity<Product>(new ProductMap().Configure); // Mapeamento de Product
            modelBuilder.Entity<Company>(new CompanyMap().Configure); // Mapeamento de Company
            modelBuilder.Entity<Input>(new InputMap().Configure); // Mapeamento de Input
            modelBuilder.Entity<Output>(new OutputMap().Configure); // Mapeamento de Input
            modelBuilder.Entity<Inventory>(new InventoryMap().Configure); // Mapeamento de Inventory

        }

    }
}
