





using System;
using System.Collections.Generic;
namespace PhoneNumbers 
{
    public class AlternateFormatsCountryCodeToRegionCodeMap
    {

        private static readonly Dictionary<int, List<String>> _countryCodeToRegionCodeMap = new Dictionary<int, List<string>>
        {
		            {
                61,
                new List<string>
                {
                }
            },
            {
                43,
                new List<string>
                {
                }
            },
            {
                55,
                new List<string>
                {
                }
            },
            {
                49,
                new List<string>
                {
                }
            },
            {
                44,
                new List<string>
                {
                }
            },
            {
                81,
                new List<string>
                {
                }
            },

        };
        

        public static Dictionary<int, List<String>> GetCountryCodeToRegionCodeMap()
        {
            return _countryCodeToRegionCodeMap;
        }
    }
}
