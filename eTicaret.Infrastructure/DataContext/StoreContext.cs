using eTicaret.Core.DbModels;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.DataContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
