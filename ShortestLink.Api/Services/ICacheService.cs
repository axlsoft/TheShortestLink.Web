namespace ShortestLink.Api.Services
{
    public interface ICacheService
    {
        string GetCachedUrl(string key);
        void SetCachedUrl(string key, string value);
    }
}