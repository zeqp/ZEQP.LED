using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.LED
{
    public static class StringHelper
    {
        public static string PadCenter(this string source, int width, char paddingChar = ' ')
        {
            var len = source.Length;
            if (source.Length >= width) return source;
            var diffWidth = len - width;
            var leftWidth = (diffWidth % 2 == 1) ? (((diffWidth - 1) / 2) + 1 + len) : ((diffWidth / 2) + len);
            return source.PadLeft(leftWidth, paddingChar).PadRight(width, paddingChar);
        }
    }
}
