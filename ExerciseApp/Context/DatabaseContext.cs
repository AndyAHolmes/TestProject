using ExerciseApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseApp.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Quote> Quote { get; set; }
    }
}