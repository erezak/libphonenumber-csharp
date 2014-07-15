﻿/*
 * Copyright (C) 2012 The Libphonenumber Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PhoneNumbers
{
    /**
    * Class encapsulating loading of PhoneNumber Metadata information. Currently this is used only for
    * additional data files such as PhoneNumberAlternateFormats, but in the future it is envisaged it
    * would handle the main metadata file (PhoneNumberMetaData.xml) as well.
    *
    * @author Lara Rennie
    */
    public class MetadataManager
    {
        internal const String ALTERNATE_FORMATS_FILE_PREFIX = "PhoneNumberAlternateFormatsProto";

        private static readonly Dictionary<int, PhoneMetadata> callingCodeToAlternateFormatsMap =
            new Dictionary<int, PhoneMetadata>();

        // A set of which country calling codes there are alternate format data for. If the set has an
        // entry for a code, then there should be data for that code linked into the resources.
        private static readonly Dictionary<int, List<String>> countryCodeSet = AlternateFormatsCountryCodeToRegionCodeMap.GetCountryCodeToRegionCodeMap();

        private MetadataManager()
        {
        }

        static private void LoadMedataFromFile(int countryCallingCode)
        {
            var fileName = ALTERNATE_FORMATS_FILE_PREFIX + "_" + countryCallingCode.ToString();

            var asm = typeof(MetadataManager).GetTypeInfo().Assembly;
            var name = asm.GetManifestResourceNames().Where(n => n.EndsWith(fileName)).FirstOrDefault() ?? "missing";
            using (var stream = asm.GetManifestResourceStream(name))
            {
                var meta = PhoneMetadataCollection.ParseFrom(stream);
                foreach (var m in meta.MetadataList)
                {
                    callingCodeToAlternateFormatsMap[m.CountryCode] = m;
                }
            }
        }

        public static PhoneMetadata GetAlternateFormatsForCountry(int countryCallingCode)
        {
            lock(callingCodeToAlternateFormatsMap)
            {
                if(!countryCodeSet.ContainsKey(countryCallingCode))
                    return null;

                if(!callingCodeToAlternateFormatsMap.ContainsKey(countryCallingCode))
                    LoadMedataFromFile(countryCallingCode);

                return callingCodeToAlternateFormatsMap.ContainsKey(countryCallingCode)
                    ? callingCodeToAlternateFormatsMap[countryCallingCode]
                    : null;
            }
        }
    }
}
