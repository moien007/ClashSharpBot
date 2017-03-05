using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClashSharpBot.Bot;

namespace ClashSharpBot
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Console.Title = string.Format("Clash Sharp Bot r{0} - Log", Global.Revision);

            Log.Init(Global.LogFileName, Log.AllLogLevels);

            // TODO : Run bot

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
