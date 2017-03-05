/*
 * Clash Sharp Bot
 * 
 * Author : Moien007
 * Desc : 
 */

using System.Drawing;
using System.Linq;

namespace ClashSharpBot.Bot.Logic
{
    public class Dialog 
    {
        public string WindowName;
        public Bitmap Image;

        /// <summary>
        /// Create New Instance of Dialog
        /// </summary>
        /// <param name="name"></param>
        /// <param name="image"></param>
        public Dialog(string name, Bitmap image)
        {
            WindowName = name;
            Image = image;
        }

        /// <summary>
        /// Is Windows Present on Screen
        /// </summary>
        /// <param name="matchSimilarity"></param>
        /// <returns></returns>
        public bool isPresent(float matchSimilarity = 98.3f)
        {
            // search window image on screen , if any coord found return true, else return false
            if (BlueStacks.TemplateMatch(this.Image, matchSimilarity).Count() < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
