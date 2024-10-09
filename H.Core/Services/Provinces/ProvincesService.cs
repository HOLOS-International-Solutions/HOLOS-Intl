using H.Core.Enumerations;
using H.Core.Services.Provinces;

namespace H.Core.Services
{
    public class ProvincesService : IProvinces
    {
        private readonly ICountrySettings _countrySettings;

        public ProvincesService(ICountrySettings countrySettings)
        {
            _countrySettings = countrySettings;
        }

        public IEnumerable<object> GetProvinces()
        {
            if (_countrySettings.Version == CountryVersion.Ireland)
            {
                return Enum.GetValues(typeof(ProvinceIreland)).Cast<object>();
            }
            else if (_countrySettings.Version == CountryVersion.Canada)
            {
                return Enum.GetValues(typeof(ProvinceCanada)).Cast<object>();
            }

            return Enumerable.Empty<object>();
        }
    }
}