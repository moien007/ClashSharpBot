/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : Collect Resource Package
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ClashSharpBot.Bot.Packages.Startup
{
    public class CollectResource : IPackage
    {
        public string PackageName
        {
            get
            {
                return "Collect Resource";
            }
        }

        public void Execute()
        {
            // TODO : Implement gold, elixir, dark elixir image for clicking
            Bitmap Gold = null; // Gold Image
            Bitmap Elixir = null; // Elixir Image
            Bitmap DarkElixir = null; // DE Image

            float Similarity = 0.98f;
            

            List<Point> CollectIcons = new List<Point>();

            // Find Collect Gold Icons and Add To List
            CollectIcons.AddRange(BlueStacks.TemplateMatch(Gold, Similarity));

            // and Elixir...
            CollectIcons.AddRange(BlueStacks.TemplateMatch(Elixir, Similarity));
            
            // and Dark Elixir
            CollectIcons.AddRange(BlueStacks.TemplateMatch(DarkElixir, Similarity));

            // Sort Icons Points
            CollectIcons.Sort();

            // And Click The Points One by One
            foreach (Point point in CollectIcons)
                BlueStacks.MouseClick(point);
        }

        public void Dispose()
        {

        }
    }
}
