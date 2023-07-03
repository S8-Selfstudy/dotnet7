global using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DbSet<SuperHero> SuperHeroes { get; set; } //Table name will be created as SuperHeroes, database name is setup in the connectionstring
    }
}
