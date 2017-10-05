using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Phaser
    {
        public int EnergyCost;
        public int Energy;
        public int Distance;

        public Phaser()
        {
            EnergyCost = 100;
            Distance = 1000;
        }

        public void TransferEnergy(int v)
        {
            Energy -= v;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}