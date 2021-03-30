using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSP.BetterCalm.Domain;


namespace MSP.BetterCalm.DataAccess
{
    public class ContextDB: DbContext
    {
        public DbSet<CategoryDto> Categories { get; set; }
       public DbSet<ProblematicDto> Problematics { get; set; }

        public ContextDB() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=BetterCalmDB;Trusted_Connection=True;MultipleActiveResultSets=True;")
                    .UseLazyLoadingProxies();
            }
            
        }
    }
}