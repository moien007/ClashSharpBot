/*
 * Clash Sharp Bot Base
 * 
 * Author : Moien007
 * Desc : Some Basic Math Methods
 */

using System;
using System.Text.RegularExpressions;

namespace ClashSharpBot.Base
{
    class BasicMath
    {
        private static readonly Regex rxNonDigits = new Regex(@"[^\d]+");

        // functions to get random number (http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c)
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public static int CleanStringOfNonDigits(string s)
        {                                               
            try
            {
                if (string.IsNullOrEmpty(s)) return 0;
                else if (s == "None") return 0;
                string cleaned = rxNonDigits.Replace(s, "");
                return int.Parse(cleaned);
            }
            catch (Exception)
            {
                return 0;
            }
        }

     
        public static int RandomInt(int a, int b)
        {
            int result;
            lock(syncLock) // FIX
            {
                result = getrandom.Next(a, b);
            }
            return result;
        }

    }
}
