using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class PhoneNumberDialer
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return raw;
            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var item in raw)
            {
                if ("-0123456789".Contains(item))
                    newNumber.Append(item);
                else
                {
                    var result = TranslateToNumber(item);
                    if (result != null)
                        newNumber.Append(result);
                    else return null;
                }
            }
             return newNumber.ToString();
        }
        static readonly string[] digits = { "ABC","DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                
                    return 2+i;
            }
            return null;
        }
    }
    
}
