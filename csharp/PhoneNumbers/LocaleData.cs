// Locale information.
// Holds a map from ISO 3166-1 country code (e.g. GB) to a dict.
// Each dict maps from an ISO 639-1 language code (e.g. ja) to the country's name in that language.
//
// Generated from java.util.Locale, generation info:
// java.version=1.6.0_26
// java.vendor=Sun Microsystems Inc.
// os.name=Windows XP
// os.arch=x86
// os.version=5.1
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
//
namespace PhoneNumbers
{
    public class LocaleData
    {
        private static Dictionary<String, Dictionary<String, String>> _Data = null;

        public static Dictionary<String, Dictionary<String, String>> Data
        {
            get
            {
                if (LocaleData._Data == null) {
                    LocaleData._Data = new Dictionary<string, Dictionary<string, string>>();
                    var asm = typeof(LocaleData).GetTypeInfo().Assembly;
                    var name = asm.GetManifestResourceNames().Where(n => n.EndsWith("localedata")).FirstOrDefault() ?? "missing";
                    using (Stream ms = asm.GetManifestResourceStream(name))
                    {
                        var serializer = new DataContractJsonSerializer(LocaleData._Data.GetType());
                        ms.Position = 0;
                        LocaleData._Data = (Dictionary<String, Dictionary<String, String>>)serializer.ReadObject(ms);
                    }
                }
                return LocaleData._Data;
            }
        }
    }
}
