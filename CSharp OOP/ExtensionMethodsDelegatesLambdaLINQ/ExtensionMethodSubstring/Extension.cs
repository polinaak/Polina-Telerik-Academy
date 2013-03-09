using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ExtensionMethodSubstring
{
    public static class Extension
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            //Check 
            if (index <= 0 || length < 0 || index > str.Length || length > str.Length)
            {
                throw new ArgumentException("Invalid values!");
            }
            
            StringBuilder result = new StringBuilder(length);
            for (int i = index; i < length+index; i++)
            {
                result.Append(str[i]);
            }
            return result;
        }
    }
}
