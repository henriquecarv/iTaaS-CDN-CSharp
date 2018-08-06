using System;

namespace iTaaS.Helpers
{
    internal class Normalize
    {
        public string GetNewFormat(string file)
        {
            return file.Replace("\"", "").Replace(" ", "|");
        }

        public Uri GetUri(string uri)
        {
            try
            {
                return new Uri(uri);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (UriFormatException)
            {
                throw;
            }
        }
    }
}