using System;
using System.Collections.Generic;

namespace Q3
{
    public static class Utilities
    {
        public static List<T2> Select<T, T2>(this List<T> list, Func<T, T2> f)
        {
            var l = new List<T2>();
            foreach (var item in list) l.Add(f(item));
            return l;
        }

        public static T SingleOrDefault<T>(this List<T> list, Func<T, bool> predicate)
        {
            var t = default(T);

            foreach (var item in list)
            {
                if (predicate(item))
                {
                    t = item;
                }
            }

            return t;
        }

        public static List<T> Where<T>(this List<T> list, Func<T, bool> predicate)
        {
            var passed = new List<T>();

            foreach (var item in list)
            {
                if (predicate(item))
                {
                    passed.Add(item);
                }
            }

            return passed;
        }

        public static T FirstOrDefault<T>(this List<T> list)
        {
            return list.Count > 0 ? list[0] : default;
        }
        
        public static T FirstOrDefault<T>(this List<T> list, Func<T, bool> predicate)
        {
            var t = default(T);

            foreach (var item in list)
            {
                if (!predicate(item)) continue;
                
                t = item;
                break;
            }

            return t;
        }

        public static List<T> OrderBy<T>(this List<T> l, Func<T, IComparable> keySelector)
        {
            var list = new List<T>(l);
            list.Sort((a, b) => keySelector(a).CompareTo(keySelector(b)));
            return list;
        }
    }
}