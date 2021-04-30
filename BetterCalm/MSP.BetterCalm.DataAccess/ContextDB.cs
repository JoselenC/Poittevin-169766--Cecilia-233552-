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
        public DbSet<AudioDto> Audios { get; set; }
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
           modelBuilder.Entity<PlaylistAudioDto>()
                .HasKey(mc => new { mc.PlaylistID, AudioID = mc.AudioID });
            modelBuilder.Entity<PlaylistAudioDto>()
                .HasOne(mc => mc.PlaylistDto)
                .WithMany(m => m.PlaylistAudiosDto)
                .HasForeignKey(mc => mc.PlaylistID);
            modelBuilder.Entity<PlaylistAudioDto>()
                .HasOne(mc => mc.AudioDto)
                .WithMany(c => c.PlaylistAudiosDto)
                .HasForeignKey(mc => mc.AudioID);
            
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
            
            modelBuilder.Entity<AudioCategoryDto>()
                .HasKey(mc => new { AudioID = mc.AudioID, mc.CategoryID });
            modelBuilder.Entity<AudioCategoryDto>()
                .HasOne(mc => mc.CategoryDto)
                .WithMany(m => m.AudiosCategoriesDto)
                .HasForeignKey(mc => mc.CategoryID);
            modelBuilder.Entity<AudioCategoryDto>()
                .HasOne(mc => mc.AudioDto)
                .WithMany(c => c.AudiosCategoriesDto)
                .HasForeignKey(mc => mc.AudioID);
            
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