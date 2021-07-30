using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace F4CIO.Restro.Common
{
    public static class Formatters
    {
        public static string ToPersianDateTime(DateTime moment)
        {
            return string.Format("{0:hh:mmtt}", moment).ToLower();
        }
    }
}
