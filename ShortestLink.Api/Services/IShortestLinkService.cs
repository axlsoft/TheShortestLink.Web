namespace ShortestLink.Api.Services
{
    public interface IShortestLinkService
    {
        string CreateShortUrl();
        bool ValidateShortUrl(string shortUrl);
    }
}
