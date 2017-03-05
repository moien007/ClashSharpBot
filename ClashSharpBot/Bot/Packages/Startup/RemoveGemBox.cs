/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : Remove Gembox Package
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClashSharpBot.Bot.Packages.Startup
{
    class RemoveGemBox : IPackage
    {
        public string PackageName
        {
            get
            {
                return "Remove Gem Box";
            }
        }

        public void Dispose()
        {

        }

        public void Execute()
        {
            // TODO : Implement GemBox image
            Bitmap GemBox = null; // Gembox Image

            List<Point> GemBoxs = BlueStacks.TemplateMatch(GemBox, 0.982f);
            
            foreach(Point gembox in GemBoxs)
            {
                // Select GemBox
                BlueStacks.MouseClick(gembox);

                if(!Buttons.Remove_GemBox.Click())
                {
                    // ERR
                }

                // Deselect Gem Box
                BlueStacks.MouseClick(1, 1);
            }
        }
    }
}
