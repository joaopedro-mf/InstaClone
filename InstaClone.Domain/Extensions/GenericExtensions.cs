using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNullOrEmpty(this string word)
        {
            return word == null || word == "";
        }

        public static bool IsNullOrEmpty(this object value)
        {
            return value == null ;
        }
    }
}
