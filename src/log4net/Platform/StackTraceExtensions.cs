using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace System.Diagnostics
{
    public static class StackTraceExtensions
    {
        public static int FrameCount(this StackTrace st)
        {
#if COREFX
            return st.GetFrames().Length;
#else
            return st.FrameCount;
#endif
        }
#if COREFX
        public static StackFrame GetFrame(this StackTrace st, int idx)
        {
            return st.GetFrames()[idx];
        }
#endif
    }
}
