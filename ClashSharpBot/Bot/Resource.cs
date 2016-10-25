/*
 * Clash Sharp Bot 
 * 
 * Author : Moien007
 * Desc : Village Resource Reporter
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClashSharpBot.Base;

namespace ClashSharpBot.Bot
{
    class Resource
    {

        #region Village Resource
        /// <summary>
        /// Get Village Gems
        /// </summary>
        public static int Gems { get; private set; }
        /// <summary>
        /// Get Village Gold
        /// </summary>
        public static int Gold { get; private set; }
        /// <summary>
        /// Get Village Elixir
        /// </summary>
        public static int Elixir { get; private set; }
        /// <summary>
        /// Get Village Dark Elixir
        /// </summary>
        public static int DarkElixir { get; private set; }
        /// <summary>
        /// Get Village Cop's
        /// </summary>
        public static int Cops { get; private set; }
        /// <summary>
        /// Village Has Dark Elixir
        /// </summary>
        public static bool hasDarkElixir { get; private set; }
        #endregion

        #region Resource Reader
        private static System.Threading.Thread thread = null;
        private static ManualResetEvent ResetEvent = new ManualResetEvent(true);

        private static bool enabled;
        public static bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if(value)
                {
                    if(thread == null)
                    {
                        thread = new Thread(new ThreadStart(readAllResource));
                        thread.Start();
                    }
                    else
                    {
                        ResetEvent.Set();
                    }
                }
                else
                {
                    ResetEvent.WaitOne();
                }
            }
        }


        private static void readAllResource()
        {
            while (true)
            {
                if(!enabled)
                {
                    ResetEvent.WaitOne();
                }

                #region ReadGold
                #endregion

                #region ReadElixir
                #endregion

                #region ReadGems
                #endregion

                #region ReadDarkElixir
                #endregion

            }
        }
        #endregion

    }
}
