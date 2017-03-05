using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClashSharpBot.Bot.Logic
{
    public class Barracks
    {
        public int
        Barbarian,
        Archer,
        Goblin,
        Giant,
        Wallbreaker,
        Balloon,
        Wizard,
        Healler,
        Dragon,
        PEKKA;

        public bool
        HasBarbarian,
        HasArcher,
        HasGoblin,
        HasGiant,
        HasWallbreaker,
        HasBalloon,
        HasWizard,
        HasHealler,
        HasDragon,
        HasPEKKA;

        public int Capacity;

        public Barracks(int size)
        {
            this.Capacity = size;
        }
    }
}
