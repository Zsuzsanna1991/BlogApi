using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class BlogDbContext : DbContext //A DbContext egy ősosztály,ami tartalmazza azokat a metódusokat, amik az adatbázis létrehozásához kellenek.
    {
        public BlogDbContext() //paraméter nélküli konstruktor a migrációk miatt
        {

        }

        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blogger> bloggers { get; set; }   //A DbSet határozza meg a tábla nevét, itt: bloggers
        public DbSet<Post> posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blog;user=root;password=;");
        }
    }
}
