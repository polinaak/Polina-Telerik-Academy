using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02SetOfExtensions
{
    public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> enumeration)
        {
            dynamic sum = 0; 
            foreach (var item in enumeration)
            {
                sum += (dynamic)item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> enumeration)
        {
            dynamic product = 1;
            foreach (var item in enumeration)
            {
                product *= (dynamic)item;
                if (product == 0)
                {
                    break;
                }
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> enumeration)
            where T: IComparable<T>
        {
            T min = enumeration.First();
            dynamic i;
            foreach (var item in enumeration)
	        {
                i = item;
                if (item.CompareTo(min) < 0)
                {
                    min = i;
                }
	        }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> enumeration)
            where T : struct, IComparable<T>, IConvertible
        {
            T max = enumeration.First();
            dynamic i;
            foreach (var item in enumeration)
            {
                i = item;
                if (item.CompareTo(max) > 0)
                {
                    max = i;
                }
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> enumeration)
            where T : struct, IComparable<T>, IConvertible
        {
            dynamic average = 0;
            dynamic sum = 0;
            int count = 0;
            foreach (var item in enumeration)
            {
                sum += (dynamic)item;
                count++;
            }
            if (count == 0)
            {
                throw new ArgumentException("The collection is empty!");
            }
            average = sum / count;
            return average;
        }
    }
}
