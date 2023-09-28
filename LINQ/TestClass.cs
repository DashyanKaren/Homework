using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class ExtMeth
    {
        public static T MyAggregate<T>(this IEnumerable<T> values, Func<T,T, T> func)
        {

                T state = default;

                foreach (var value in values)
                {
                    state = func(state, value);
                }

                return state;

        }
        public static bool MyAll<T>(this IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var item in values)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool MyAny<T>(this IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var item in values)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
