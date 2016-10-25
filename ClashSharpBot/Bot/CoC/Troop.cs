using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashSharpBot.Bot.CoC
{
    public class Troop
    {
        public int count;
        public TroopType Type;
        public Button Button;

        /// <summary>
        /// Create New Instance of Troop
        /// </summary>
        /// <param name="type"></param>
        /// <param name="btn"></param>
        public Troop(TroopType type, Button btn)
        {
            this.Type = type;
            this.Button = btn;
        }

        public enum TroopType : int
        {
            Barbarian = 0,
            Archer = 1,
            Goblin = 2,
            Giant = 3,
            Wallbreaker = 4,
            Balloon = 5,
            Wizard = 6,
            Healler = 7,
            Dragon = 8,
            PEKKA = 9,
                        
            Minion = 10,
            HogRider = 11,
            Valkyrie = 12,
            Golem = 13,
            Witch = 14,

            BarbarianKing = 15,
            ArcherQueen = 16
        }
    }
}
