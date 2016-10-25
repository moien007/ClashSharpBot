/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : Clear Tombstones Package
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClashSharpBot.Bot.Packages.Startup
{
    class ClearTombstones
    {
        public static void Execute()
        {
            Bitmap Tombstone = null; // Tombstone Image

            // Find Tombstones
            // Select First From List
            // Send Click
            BlueStacks.MouseClick(BlueStacks.TemplateMatch(Tombstone, 0.986f).FirstOrDefault());
        }
    }
}
