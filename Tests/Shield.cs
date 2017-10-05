using System;

namespace StarTrekNextGeneration
{
    internal class Shield
    {
        public bool IsUp { get; internal set; }
        public int Energy { get; internal set; }
        public const int StartingEnergy = 10000;
         
        public Shield()
        {
            IsUp = false;
            Energy = StartingEnergy;
        }

        internal void Raise()
        {
            IsUp = true;
        }

        internal void TakeHit(int v)
        {
            Energy -= v;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}