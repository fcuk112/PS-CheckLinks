using Microsoft.EntityFrameworkCore;

namespace CheckLinksConsole
{
    public class LinksDb : DbContext
    {
        public DbSet<LinkCheckResult> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=localhost;Database=Links;User Id=sa;Password=Whatever12!";
            optionsBuilder.UseSqlServer(connection);

        }
    }
}