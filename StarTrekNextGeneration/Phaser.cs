using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Phaser : SubSystem
    {
        public int EnergyCost;
        public int Energy;
        public int Distance;

        public Phaser()
        {
            systemName = "Phaser";
            EnergyCost = 100;
            Distance = 1000;
        }

        public void TransferEnergy(int energyAmount)
        {
            Energy -= energyAmount;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}