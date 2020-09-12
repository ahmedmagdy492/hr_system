using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace hr_system.Utility
{
    public static class Converter
    {
        public static StringBuilder ConvertToStringBuilder(string content)
        {
            return new StringBuilder(content);
        }

        public static string ConvertToByteArrayToStringBuilder(byte[] content)
        {
            string str = string.Empty;
            for(int i = 0; i < content.Length; i++)
            {
                str += content[i].ToString("x2");
            }
            return str;
        }
    }
}