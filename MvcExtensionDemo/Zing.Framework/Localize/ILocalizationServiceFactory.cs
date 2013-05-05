 
using System.Globalization;

namespace Zing.Framework.Localize
{
    public interface ILocalizationServiceFactory
    {
        ILocalizationService Create(string resourceName, CultureInfo culture);
    }
}
