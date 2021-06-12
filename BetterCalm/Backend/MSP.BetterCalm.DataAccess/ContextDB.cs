using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.DataAccess
{
    public class ContextDb: DbContext
    { 
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProblematicDto> Problematics { get; set; }
        public DbSet<ContentDto> Contents { get; set; }
        public DbSet<PatientDto> Patients { get; set; }
        public DbSet<PsychologistDto> Psychologists { get; set; }
        public DbSet<AdministratorDto> Administrators { get; set; }
        public DbSet<PlaylistDto> Playlists { get; set; }
        public DbSet<PsychologistProblematicDto> PsychologistProblematic { get; set; }
        public DbSet<MeetingDto> Meeting { get; set; }
        public DbSet<VoucherDto> Vouchers { get; set; }

        public ContextDb() { }
        public ContextDb(DbContextOptions<ContextDb> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<PlaylistContentDto>()
                .HasKey(mc => new { PlaylistID = mc.PlaylistId, ContentID = mc.ContentId });
            modelBuilder.Entity<PlaylistContentDto>()
                .HasOne(mc => mc.PlaylistDto)
                .WithMany(m => m.PlaylistContentsDto)
                .HasForeignKey(mc => mc.PlaylistId);
            modelBuilder.Entity<PlaylistContentDto>()
                .HasOne(mc => mc.ContentDto)
                .WithMany(c => c.PlaylistContentsDto)
                .HasForeignKey(mc => mc.ContentId);
            
            
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasKey(mc => new { PlaylistID = mc.PlaylistId, CategoryID = mc.CategoryId });
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasOne(mc => mc.PlaylistDto)
                .WithMany(m => m.PlaylistCategoriesDto)
                .HasForeignKey(mc => mc.PlaylistId);
            modelBuilder.Entity<PlaylistCategoryDto>()
                .HasOne(mc => mc.CategoryDto)
                .WithMany(c => c.PlaylistCategoriesDto)
                .HasForeignKey(mc => mc.CategoryId);
            
            modelBuilder.Entity<ContentCategoryDto>()
                .HasKey(mc => new { ContentID = mc.ContentId, CategoryID = mc.CategoryId });
            modelBuilder.Entity<ContentCategoryDto>()
                .HasOne(mc => mc.CategoryDto)
                .WithMany(m => m.ContentsCategoriesDto)
                .HasForeignKey(mc => mc.CategoryId);
            modelBuilder.Entity<ContentCategoryDto>()
                .HasOne(mc => mc.ContentDto)
                .WithMany(c => c.ContentsCategoriesDto)
                .HasForeignKey(mc => mc.ContentId);
            
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