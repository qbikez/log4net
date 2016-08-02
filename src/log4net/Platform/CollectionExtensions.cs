using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Collections
{
    public static class CollectionExtensions
    {
        public static T[] ToArray<T>(this IList<T> list)
        {
            var a = new T[list.Count];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = list[i];
            }

            return a;
        }

        public static object[] ToArray(this IList list, Type t)
        {
            var a = Array.CreateInstance(t, list.Count);
            for (int i = 0; i < a.Length; i++)
            {
                a.SetValue(list[i], i);
            }
            
            return (object[])a;
        }
    }
}
