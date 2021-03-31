
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MSP.BetterCalm.DataAccess;

namespace  Homeworks.DataAccess
{
    public  enum  ContextType { MEMORY, SQL }

    public class ContextFactory : IDesignTimeDbContextFactory<DbContext>

    {
    public DbContext CreateDbContext(string[] args)
    {
        return GetNewContext();
    }

    public static DbContext GetNewContext(ContextType type = ContextType.SQL)
    {
        var builder = new DbContextOptionsBuilder<DbContext>();
        DbContextOptions options = null;
        if (type == ContextType.MEMORY)
        {
            options = GetMemoryConfig(builder);
        }
        else
        {
            options = GetSqlConfig(builder);
        }

        return new DbContext(options);
    }

    private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder)
    {
        builder.UseInMemoryDatabase("BetterCalmDB");

        return builder.Options;
    }

    private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder)
    {
        //TODO: Se puede mejorar esto colocando en un archivo externo y obteniendo
        // desde allí la información.
        builder.UseSqlServer(
            @"Server=.\\SQLEXPRESS;Database=BetterCalmDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        return builder.Options;
    }
    }
}