using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using MSP.BetterCalm.Domain;


namespace MSP.BetterCalm.DataAccess
{
    public class ContextDB: DbContext
    { 
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProblematicDto> Problematics { get; set; }
        public DbSet<SongDto> Songs { get; set; }
        public DbSet<PlaylistDto> Playlists { get; set; }
        
        public ContextDB() { }
        public ContextDB(DbContextOptions<ContextDB> options): base(options) { }


        [ExcludeFromCodeCoverage]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDto>()
                .HasOne<SongDto>(s => s.SongDto)
                .WithMany(g => g.Categories)
                .HasForeignKey(x => x.SongDtoID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<CategoryDto>()
                .HasOne<PlaylistDto>(s => s.PlaylistDto)
                .WithMany(g => g.Categories)
                .HasForeignKey(x => x.PlaylistDtoID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SongDto>()
                .HasOne<PlaylistDto>(s => s.PlaylistDto)
                .WithMany(g => g.Songs)
                .HasForeignKey(x=>x.PlaylistDtoID)
                .OnDelete(DeleteBehavior.SetNull);
        }

        [ExcludeFromCodeCoverage]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString(@"BetterCalmDB");
                optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        
            }
        }        
    }
}