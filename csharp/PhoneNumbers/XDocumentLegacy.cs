using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace libphonenumber_csharp_portable {
    static class XDocumentLegacy {
        internal static IEnumerable<XElement> GetElementsByTagName(this XDocument document, string tagName) {
            return (from d in document.Descendants() where d.Name.LocalName == tagName select d);
        }

        internal static IEnumerable<XElement> GetElementsByTagName(this XElement document, string tagName) {
            return (from d in document.Descendants() where d.Name.LocalName == tagName select d);
        }

        internal static bool HasAttribute(this XElement element, string attribute) {
            return (element.Attribute(attribute) != null);
        }

        internal static string GetAttribute(this XElement element, string attribute) {
            string value;

            if (element.HasAttribute(attribute)) {
                value = element.Attribute(attribute).Value;
            } else {
                value = "";
            }

            return value;
        }
    }
}
