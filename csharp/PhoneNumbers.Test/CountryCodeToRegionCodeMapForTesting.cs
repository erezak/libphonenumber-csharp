





using System;
using System.Collections.Generic;
namespace PhoneNumbers 
{
    public class CountryCodeToRegionCodeMapForTesting
    {

        private static readonly Dictionary<int, List<String>> _countryCodeToRegionCodeMap = new Dictionary<int, List<string>>
        {
		            {
                376,
                new List<string>
                {
                    "AD",
                }
            },
            {
                244,
                new List<string>
                {
                    "AO",
                }
            },
            {
                54,
                new List<string>
                {
                    "AR",
                }
            },
            {
                61,
                new List<string>
                {
                    "AU",
                }
            },
            {
                55,
                new List<string>
                {
                    "BR",
                }
            },
            {
                1,
                new List<string>
                {
                    "US",
                    "BS",
                }
            },
            {
                49,
                new List<string>
                {
                    "DE",
                }
            },
            {
                44,
                new List<string>
                {
                    "GB",
                }
            },
            {
                39,
                new List<string>
                {
                    "IT",
                }
            },
            {
                81,
                new List<string>
                {
                    "JP",
                }
            },
            {
                82,
                new List<string>
                {
                    "KR",
                }
            },
            {
                52,
                new List<string>
                {
                    "MX",
                }
            },
            {
                64,
                new List<string>
                {
                    "NZ",
                }
            },
            {
                48,
                new List<string>
                {
                    "PL",
                }
            },
            {
                262,
                new List<string>
                {
                    "RE",
                    "YT",
                }
            },
            {
                65,
                new List<string>
                {
                    "SG",
                }
            },
            {
                800,
                new List<string>
                {
                    "001",
                }
            },
            {
                979,
                new List<string>
                {
                    "001",
                }
            },

        };
        

        public static Dictionary<int, List<String>> GetCountryCodeToRegionCodeMap()
        {
            return _countryCodeToRegionCodeMap;
        }
    }
}
