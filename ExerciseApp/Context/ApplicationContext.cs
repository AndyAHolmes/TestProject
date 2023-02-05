using ExerciseApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseApp.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }
        public virtual DbSet<QuoteEstimation> QuoteEstimations { get; set; }
    }
}
