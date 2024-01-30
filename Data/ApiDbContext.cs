using Apicomics.Models;
using Microsoft.EntityFrameworkCore;

namespace Apicomics.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Comic> Comics { get; set; }
    }
    
}
