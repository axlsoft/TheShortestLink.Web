using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ShortestLink.Api.Services
{
    public class ShortestLinkService : IShortestLinkService
    {
        private const string urlCharacters = "AEFHKLMNPRSTWXYZ23456789";
        private Random random = new Random();

        public string CreateShortUrl()
        {
            var result = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                result.Append(urlCharacters[random.Next(urlCharacters.Length)]);
            }

            return result.ToString();
        }

        public bool ValidateShortUrl(string shortUrl)
        {
            return Regex.IsMatch(shortUrl, @"^[AEFHKLMNPRSTWXYZ23456789]{8}$");
        }
    }
}