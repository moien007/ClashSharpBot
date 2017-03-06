/*
 * Clash Sharp Bot Base
 * 
 * Author : Moien007
 * Desc : Some Basic Math Methods
 */

using System;

namespace ClashSharpBot
{
    class BasicMath
    {
        // functions to get random number (http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c)
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public static int CleanStringOfNonDigits(string s)
        {
            string cleaned = string.Empty;

            foreach(char c in s)
            {
                if (!char.IsNumber(c)) continue;

                cleaned += c;
            }

            int i;

            if(!int.TryParse(cleaned,  out i))
            {
                return 0;
            }

            return i;
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
