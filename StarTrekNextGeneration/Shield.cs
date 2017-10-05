﻿namespace StarTrekNextGeneration
{
    public class Shield
    {
        public bool IsUp { get;  set; }
        public int Energy { get;  set; }

        public const int StartingEnergy = 10000;

        public Shield()
        {
            IsUp = false;
            Energy = StartingEnergy;
        }

        public void Raise()
        {
            IsUp = true;
        }

        public void Drop()
        {
            IsUp = false;
        }

        public void TakeHit(int v)
        {
            Energy -= v;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}