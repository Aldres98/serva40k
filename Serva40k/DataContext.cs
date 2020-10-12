using Microsoft.EntityFrameworkCore;
using Serva40k.Models;

namespace Serva40k
{
    public class DataContext : DbContext
    {
        public DbSet<TestDataModel> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

    }
}
    