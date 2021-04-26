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
        public DbSet<PatientDto> Patients { get; set; }
        public DbSet<PsychologistDto> Psychologists { get; set; }
        public DbSet<AdministratorDto> Administrators { get; set; }


        public DbSet<PlaylistDto> Playlists { get; set; }
        
        public ContextDB() { }
        public ContextDB(DbContextOptions<ContextDB> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<PlaylistSongDto>()
                .HasKey(mc => new { mc.PlaylistID, mc.SongID });
            modelBuilder.Entity<PlaylistSongDto>()
                .HasOne(mc => mc.PlaylistDto)
                .WithMany(m => m.PlaylistSongsDto)
                .HasForeignKey(mc => mc.PlaylistID);
            modelBuilder.Entity<PlaylistSongDto>()
                .HasOne(mc => mc.SongDto)
                .WithMany(c => c.PlaylistSongsDto)
                .HasForeignKey(mc => mc.SongID);
            
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasKey(mc => new { mc.PlaylistID, mc.CategoryID });
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasOne(mc => mc.PlaylistDto)
                .WithMany(m => m.PlaylistCategoriesDto)
                .HasForeignKey(mc => mc.PlaylistID);
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasOne(mc => mc.CategoryDto)
                .WithMany(c => c.PlaylistCategoriesDto)
                .HasForeignKey(mc => mc.CategoryID);
            
            modelBuilder.Entity<SongCategoryDto>()
                .HasKey(mc => new { mc.SongID, mc.CategoryID });
            modelBuilder.Entity<SongCategoryDto>()
                .HasOne(mc => mc.CategoryDto)
                .WithMany(m => m.SongsCategoriesDto)
                .HasForeignKey(mc => mc.CategoryID);
            modelBuilder.Entity<SongCategoryDto>()
                .HasOne(mc => mc.SongDto)
                .WithMany(c => c.SongsCategoriesDto)
                .HasForeignKey(mc => mc.SongID);
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
                optionsBuilder.UseSqlServer(connectionString);
        
            }
        }        
    }
}