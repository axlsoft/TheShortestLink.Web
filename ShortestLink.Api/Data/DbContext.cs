using Microsoft.EntityFrameworkCore;
using ShortestLink.Api.Model;

namespace ShortestLink.Api.Data
{

    public class URLShortenerContext : DbContext
    {
        public URLShortenerContext(DbContextOptions<URLShortenerContext> options) : base(options)
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}