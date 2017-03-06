/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : Zoom Out Package
 */

using System.Threading;


/*
 * Okay !!! Look, How Much Line of Code Writed Here to Do Zoom out ?
 * Look at Another Open Sourced COC Bots and Compare With This :)
 */

namespace ClashSharpBot.Bot.Packages.Startup
{
    class ZoomOut
    {
        public static void Execute()
        {
            while(!ColorPoints.Village_ZoomOut.Present)
            {
                // Send Key
                BlueStacks.Send("{DOWN}");

                // Random Delay For Work Like Human
                Thread.Sleep(Base.BasicMath.RandomInt(100, 1500));
            }
        }
    }
}
