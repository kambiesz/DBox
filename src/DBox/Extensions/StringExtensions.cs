using System;
using System.Collections.Generic;
using System.Text;

namespace DBox.Extensions
{
    public static class StringExtensions
    {
        public static string IfEmpty(this string str, string value)
        {
            return string.IsNullOrEmpty(str) ? value : str;
        }

        public static string DefaultIfEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) ? "" : str;
        }
    }
}
