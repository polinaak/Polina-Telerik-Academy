using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ApplicationException
{
    public class InvalidRangeException<T>
        : ApplicationException
        where T : struct, IComparable, IComparable<T>, IEquatable<T>, IConvertible, IFormattable
    {
        private T min;
        private T max;

        public T Min
        {
            get { return min; }
        }
        public T Max
        {
            get { return max; }
        }

        public InvalidRangeException(string msg, T min, T max, Exception innerEx)
            : base(msg, innerEx)
        {
            this.min = min;
            this.max = max;
        }
        public InvalidRangeException(string msg, T min, T max)
            : this(msg, min, max, null)
        { }

    }
}
