#if COREFX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public class ApplicationException : Exception
    {
        public ApplicationException()
        {

        }

        public ApplicationException(string msg) : base(msg)
        {

        }

        public ApplicationException(string msg, Exception inner) : base(msg, inner)
        {

        }
    }
}

#endif