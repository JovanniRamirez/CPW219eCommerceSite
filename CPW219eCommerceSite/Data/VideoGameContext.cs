using Microsoft.EntityFrameworkCore;

namespace CPW219eCommerceSite.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
    {
    }
}
