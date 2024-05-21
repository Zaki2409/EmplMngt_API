using EmplMngt.Model;
using Microsoft.EntityFrameworkCore;

namespace EmplMngt.Data
{
    public class EmplMngtDbContext :DbContext
    {
        public EmplMngtDbContext(DbContextOptions options) : base(options) { }
        
        // MODELS/TABLES
        public DbSet<Employee> Employees { get; set; }
    }
}
