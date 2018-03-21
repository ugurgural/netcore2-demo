using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore2Demo.Entities.Config;
using NetCore2Demo.Entities.Domain;

namespace NetCore2Demo.DataRepository.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        /// <summary>
        /// Get or sets the product data model
        /// </summary>
        public DbSet<Product> Product { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}