using System;

namespace iTaaS.Helpers
{
    public class Version
    {
        public decimal GetAssemblyVersion<T>(decimal appVersion)
        {
            try
            {
                var version = typeof(T).Assembly.GetName().Version;
                var stringVersion = $"{version.Major}.{version.Minor}";
                return Decimal.Parse(stringVersion);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
        }
    }
}