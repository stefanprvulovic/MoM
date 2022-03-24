using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MoMContext : DbContext
    {
        public DbSet<Odsek> Odseci { get; set;}
        public DbSet<Radnik> Radnici {get; set;}
        public DbSet<Slucaj> Slucajevi {get; set;}
        public DbSet<Ministarstvo> Ministarstva { get; set; }

        public MoMContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Radnik>()
                .HasMany(x => x.Slucajevi)
                .WithOne(p => p.Radnik);
         // Radnik moze da radi na vise slucajeva,
                                        // a 1 slucaj moze da resava 1 radnik
            modelBuilder.Entity<Odsek>()
                .HasMany(x => x.Radnici);
        }
    }
}