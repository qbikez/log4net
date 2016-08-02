using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class StreamExtensions
    {
#if COREFX
        public static void Close(this Stream stream)
        {
            stream.Dispose();
        }

        public static void Close(this TextWriter writer)
        {
            writer.Dispose();
        }

#endif
    }
}
