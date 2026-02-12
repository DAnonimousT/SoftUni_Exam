using SoftUni_Exam.Models;
using Microsoft.EntityFrameworkCore;


namespace SoftUni_Exam.Data
{
    public class ImpulsDbContext : DbContext
    {
        public ImpulsDbContext(DbContextOptions<ImpulsDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Competitions> Competitions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImpulsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}