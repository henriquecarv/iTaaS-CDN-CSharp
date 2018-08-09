using System;

namespace iTaaS.Helpers
{
    public class Normalize
    {
        public string GetNewFormat(string file)
        {
            return file.Replace("\"", "").Replace(" ", "|");
        }

        public Uri ValidateURL(string uri)
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