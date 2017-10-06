namespace StarTrekNextGeneration
{
    public class Shield : SubSystem
    {
        public bool IsUp { get;  set; }
        public int Energy { get;  set; }
        public const int EnergyMax = 10000;
        public const int StartingEnergy = 10000;

        public Shield()
        {
            systemName = "Shield";
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

        public void TakeHit(int damageToShield)
        {
            Energy -= damageToShield;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}