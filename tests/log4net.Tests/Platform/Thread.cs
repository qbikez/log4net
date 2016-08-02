using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace System.Threading
{
    public class ThreadUtils
    {
        public static CultureInfo CurrentThreadCulture
        {
            get
            {
                return CultureInfo.CurrentCulture;
            }
            set
            {
                CultureInfo.CurrentCulture = value;
            }
        }

        public static CultureInfo CurrentThreadUICulture
        {
            get
            {
                return CultureInfo.CurrentUICulture;
            }
            set
            {
                CultureInfo.CurrentUICulture = value;
            }
        }
        }
}
