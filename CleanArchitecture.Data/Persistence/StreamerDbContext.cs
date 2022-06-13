using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-A20PC6S;Initial Catalog= Streamer;User ID=josias;Password=Josias458;Trusted_Connection=false;MultipleActiveResultSets=true")
        //        .LogTo(
        //            Console.WriteLine
        //            , new[] { DbLoggerCategory.Database.Command.Name }
        //            , LogLevel.Information
        //        )
        //        .EnableSensitiveDataLogging();
        //}

        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        item.Entity.CreatedBy = "System";
                        break;
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.Now;
                        item.Entity.LastModifiedBy = "System";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Director>()
                .HasMany(v => v.Videos)
                .WithOne(d => d.Director)
                .HasForeignKey(d => d.DirectorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(a => a.Actores)
                .WithMany(b => b.Videos)
                .UsingEntity<VideoActor>(
                    j => j
                        .HasOne(p => p.Actor)
                        .WithMany(p => p.VideoActors)
                        .HasForeignKey(p => p.ActorId),
                    j => j
                        .HasOne(p => p.Video)
                        .WithMany(p => p.VideoActors)
                        .HasForeignKey(p => p.VideoId),
                    j =>
                    {
                        j.HasKey(t => new { t.ActorId, t.VideoId });
                    }
                );
            modelBuilder.Entity<VideoActor>().Ignore(x => x.Id);
        }

        public DbSet<Streamer>? Streamers { get; set; }

        public DbSet<Video>? Videos { get; set; }

        public DbSet<Actor>? Actores { get; set; }

        public DbSet<Director>? Directores { get; set; }
    }
}
