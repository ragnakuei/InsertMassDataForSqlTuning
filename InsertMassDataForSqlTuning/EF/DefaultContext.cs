using InsertMassDataForSqlTuning.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InsertMassDataForSqlTuning.EF
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>()
                        .ToTable("Dept", "dbo")
                        .HasKey(t => t.Id);

            modelBuilder.Entity<DeptLevel>()
                        .ToTable("DeptLevel", "dbo")
                        .HasKey(t => t.Id);
        }

        public DbSet<Dept>      Depts      { get; set; }
        public DbSet<DeptLevel> DeptLevels { get; set; }
    }
}