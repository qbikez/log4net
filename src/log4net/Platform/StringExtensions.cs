using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
#if COREFX
        public static string ToLower(this string str, System.Globalization.CultureInfo cultureInfo)
        {
            return str.ToLower();
        }

        public static string ToUpper(this string str, System.Globalization.CultureInfo cultureInfo)
        {
            return str.ToUpper();
        }

        public static string ToString(this char c, System.Globalization.CultureInfo cultureInfo)
        {
            return c.ToString();
        }
#endif
    }

    public static class StringUtils
    {
        public static int Compare(string s1, string s2, bool ignorecase, CultureInfo culture)
        {
            return string.Compare(s1, s2, ignorecase);
        }

        internal static int Compare(string s1, int offset1, string s2, int offset2, int length, bool ignorecase, CultureInfo culture)
        {
            return string.Compare(s1, offset1, s2, offset2, length,
                culture == CultureInfo.CurrentCulture ? 
                    (ignorecase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture)
                    : (ignorecase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)
                    );
        }
    }
}
