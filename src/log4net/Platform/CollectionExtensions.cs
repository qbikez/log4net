﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Collections
{
    public static class CollectionExtensions
    {
       
        public static object GetSyncRoot<T>(this ICollection<T> collection)
        {
#if !COREFX
			return collection.SyncRoot; 
#else
            return collection;
#endif
        }


        public static bool IsArraySynchronized(this Array array)
        {
#if !COREFX
			return array.IsSynchronized; 
#else
            return true;
#endif
        }



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

namespace System.Collections.Specialized
{
    public class CollectionsUtil
    {
        public static Hashtable CreateCaseInsensitiveHashtable()
        {
            return new CaseInsensitiveHashtable();
        }
    }
}