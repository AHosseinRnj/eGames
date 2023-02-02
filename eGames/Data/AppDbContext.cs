using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // VoiceActor_Game
            modelBuilder.Entity<VoiceActor_Game>().HasKey(vag => new
            {
                vag.VoiceActorId,
                vag.GameId
            });
            modelBuilder.Entity<VoiceActor_Game>().HasOne(g => g.Game).WithMany(vag => vag.VoiceActors_Games).HasForeignKey(g => g.GameId);
            modelBuilder.Entity<VoiceActor_Game>().HasOne(g => g.VoiceActor).WithMany(vag => vag.VoiceActors_Games).HasForeignKey(g => g.VoiceActorId);

            // Developer_Game
            modelBuilder.Entity<Developer_Game>().HasKey(dg => new
            {
                dg.DeveloperId,
                dg.GameId
            });
            modelBuilder.Entity<Developer_Game>().HasOne(g => g.Game).WithMany(dg => dg.Developers_Games).HasForeignKey(g=>g.GameId);
            modelBuilder.Entity<Developer_Game>().HasOne(g => g.Developer).WithMany(dg => dg.Developers_Games).HasForeignKey(g => g.DeveloperId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<VoiceActor> VoiceActors { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<VoiceActor_Game> VoiceActors_Games { get; set; }
        public DbSet<Developer_Game> Developers_Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}