using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
#if COREFX 
    public class SerializableAttribute : Attribute
    {
    }

    public interface ISerializable
    {

    }
#endif
}
