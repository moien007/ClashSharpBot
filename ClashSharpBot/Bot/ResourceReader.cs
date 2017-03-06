using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClashSharpBot.Bot
{
    class ResourceReader
    {
        static ILogger Logger = Log.GetLogger("ResourceReader");

        public static event Action OnResourceRead;

        public static int Gem { get; private set; } = 0;
        public static int Gold { get; private set; } = 0;
        public static int Elixir { get; private set; } = 0;
        public static int DarkElixir { get; private set; } = 0;

        static bool _Work = false;
        static Thread thread = null;

        public static bool Work
        {
            get
            {
                return _Work;
            }
            set
            {
                _Work = value;

                if(value && thread != null)
                {
                    Logger.Info("Resource reader resumed");
                }
                else
                {
                    Logger.Info("Resource reader started");
                }

                if(thread == null)
                {
                    thread = new Thread(ResourceThread);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }

        static void ResourceThread()
        {
            Logger.Info("Resource reader thread started");

            while(true)
            {
                if (_Work == false || BlueStacks.IsRunning == false) continue;

                // if icon of gem resource exist (on the top right)
                if(ColorPoints.Village_Resource_Gem.Present)
                {
                    // read gem, gold, elixir

                    Gem = ReadPoints.Village_Resource_Gem.ReadNumber();
                    Gold = ReadPoints.Village_Resource_Gold.ReadNumber();
                    Elixir = ReadPoints.Village_Resource_Elixir.ReadNumber();

                    // if icon of dark elixir doesnt exist
                    if(ColorPoints.Village_Resource_DarkElixir.Present)
                    {
                        DarkElixir = ReadPoints.Village_Resource_DarkElixir.ReadNumber();
                    }

                    // raise on resource read event
                    OnResourceRead?.Invoke();
                }
            }
        }
    }
}
