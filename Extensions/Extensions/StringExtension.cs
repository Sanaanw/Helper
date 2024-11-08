using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtension
    {
        public static bool IsContainsDigit(this string Str)//this sorsindaki extension cagrdgmz yerin qabagindakidir.wordun sorsaindaki
        {
           foreach (var item in Str)
            {
                if(char.IsDigit(item)) return true;
            }
           return false;
        }
    }
}
