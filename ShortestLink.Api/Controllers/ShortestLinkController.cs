using System;
using Microsoft.AspNetCore.Mvc;
using ShortestLink.Api.Services;

namespace ShortestLink.Api.Controllers
{
    [ApiController]
    [Route("u")]
    public class ShortestController : ControllerBase
    {
        private IShortestLinkService _shortener;
        private ICacheService _cache;

        public ShortestController(IShortestLinkService shortener, ICacheService cache)
        {
            _shortener = shortener;
            _cache = cache;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string originalUrl)
        {
            if (Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            {
                string shortUrl;
                do
                {
                    shortUrl = _shortener.CreateShortUrl();
                }
                while (_cache.GetCachedUrl(shortUrl) != null);

                _cache.SetCachedUrl(shortUrl, originalUrl);

                return Ok(shortUrl);
            }

            return BadRequest("Invalid URL");
        }

        [HttpGet("{shortUrl}")]
        public IActionResult Get(string shortUrl)
        {
            if (!_shortener.ValidateShortUrl(shortUrl))
                return BadRequest("Invalid short URL");

            var originalUrl = _cache.GetCachedUrl(shortUrl);

            if (originalUrl == null)
                return NotFound();

            return Redirect(originalUrl);
        }
    }
}