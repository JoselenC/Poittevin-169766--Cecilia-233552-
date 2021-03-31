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
        public ContextDB(DbContextOptions<ContextDB> options): base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}