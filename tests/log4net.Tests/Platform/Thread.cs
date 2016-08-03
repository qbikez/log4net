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
#if COREFX
                return CultureInfo.CurrentCulture;
#else
                return Thread.CurrentThread.CurrentCulture;
#endif
            }
            set
            {
#if COREFX
                CultureInfo.CurrentCulture = value;
#else
                Thread.CurrentThread.CurrentCulture = value;
#endif
            }
        }

        public static CultureInfo CurrentThreadUICulture
        {
            get
            {
#if COREFX
                return CultureInfo.CurrentUICulture;
#else
                return Thread.CurrentThread.CurrentUICulture;
#endif
            }
            set
            {
#if COREFX
                CultureInfo.CurrentUICulture = value;
#else
                Thread.CurrentThread.CurrentUICulture = value;
#endif
            }
        }

    }
        }
