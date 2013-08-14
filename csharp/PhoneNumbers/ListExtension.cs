using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libphonenumber_csharp_portable {
    internal static class ListExtension {
        internal static List<TOutput> ConvertAll<TOutput>(this List<char> list, Func<char, TOutput> converter) {
            List<TOutput> returnedList = new List<TOutput>(list.Count);
            foreach (char character in list) {
                returnedList.Add(converter(character));
            }
            return returnedList;
        }
    }
}
