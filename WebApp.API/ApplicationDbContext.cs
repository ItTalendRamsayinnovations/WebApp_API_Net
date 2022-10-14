using Microsoft.EntityFrameworkCore;
using WebApp.API.Entities;

namespace WebApp.API
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Career> Career { get; set; }
    }
}
