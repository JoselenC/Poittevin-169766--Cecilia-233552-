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
        public DbSet<PsychologistProblematicDto> PsychologistProblematic { get; set; }
        public DbSet<MeetingDto> Meeting { get; set; }

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
            
            modelBuilder.Entity<PsychologistProblematicDto>()
                .HasKey(pp => new { pp.PsychologistId, pp.ProblematicId });
            modelBuilder.Entity<PsychologistProblematicDto>()
                .HasOne(pp => pp.Psychologist)
                .WithMany(p => p.Problematics)
                .HasForeignKey(pp => pp.PsychologistId);
            modelBuilder.Entity<PsychologistProblematicDto>()
                .HasOne(pp => pp.Problematic)
                .WithMany(p => p.PsychologistProblematic)
                .HasForeignKey(pp => pp.ProblematicId);
            
            modelBuilder.Entity<MeetingDto>()
                .HasKey(m => new { m.PsychologistId, m.PatientId, m.DateTime });
            modelBuilder.Entity<MeetingDto>()
                .HasOne(m => m.Patient)
                .WithMany(p => p.Meetings)
                .HasForeignKey(m => m.PatientId);
            modelBuilder.Entity<MeetingDto>()
                .HasOne(pp => pp.Psychologist)
                .WithMany(p => p.Meetings)
                .HasForeignKey(m => m.PsychologistId);
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