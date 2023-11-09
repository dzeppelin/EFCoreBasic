using Microsoft.EntityFrameworkCore;

namespace EFCoreBasic.Database;

public class Context : DbContext
{
    private const string ConnectionString = @"Server=localhost;Port=5430;Database=postgres;Uid=admin;Pwd=admin;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }

    /*
     * No property for Author table, that's on purpose
     * Navigational property for Author in Book class will do it for us
    */

    // Classes that should be mapped to the database
    public DbSet<Book> Books { get; set; }
}
