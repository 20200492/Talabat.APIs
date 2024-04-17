using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Repository.Data.Config;

namespace Talabat.Repository
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> Option):base(Option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.ApplyConfiguration(new ProductConfigrations());
            ///modelBuilder.ApplyConfiguration(new ProductBrandConfigrations());
            ///modelBuilder.ApplyConfiguration(new ProductCategoryConfigrations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly .GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
