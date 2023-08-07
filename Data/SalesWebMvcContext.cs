using SalesWebMvc.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
