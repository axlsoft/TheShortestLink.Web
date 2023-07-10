using System.ComponentModel.DataAnnotations;

namespace ShortestLink.Api.Model
{
    public class ShortenedUrl
    {
        [Key]
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public int ClickCount { get; set; }
    }
}