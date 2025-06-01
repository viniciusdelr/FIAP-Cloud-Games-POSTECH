using Microsoft.EntityFrameworkCore;
using FCG.Entities;

namespace FCG.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
    }
}