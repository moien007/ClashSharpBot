using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClashSharpBot.Bot;

namespace ClashSharpBot
{
    static class Program
    {
        public static int revision = 0;
        public static string DataFolder = @"Data\";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Console.Title = string.Format("Clash Sharp Bot r{0} - Log", revision);
            Console.WriteLine("Clash Sharp Bot Project Startup\n");

            Log.Init(LogLevel.Warn | LogLevel.Info | LogLevel.Error | LogLevel.Debug);

            Log.Debug("BlueStacks.Init()");
            if(!BlueStacks.Init())
            {
                Log.Error("BlueStacks.Init() Failure !");
                
            }


            BotThread.Work = true; // Start bot
            //BotThread.Work = false; Pause Bot

            Log.Info("Main Loop Started");
            while(true)
            {
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("End of Program !!!");
            Console.ReadKey();
        }
    }
}
