using System;
using System.Collections.Generic;

namespace PhoneNumbersConverter
{
    public partial class CountryCodeToRegionCodeMapGenerator
    {
        private readonly string _ns;
        private readonly string _className;
        private readonly IReadOnlyDictionary<int, List<string>> _map;

        public CountryCodeToRegionCodeMapGenerator(string @namespace, string className, IReadOnlyDictionary<int, List<String>> map)
        {
            _ns = @namespace;
            _className = className;
            _map = map;
        }
    }
}
