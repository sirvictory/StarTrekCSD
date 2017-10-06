using System;
using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Ship
    {
        public Shield shield;
        public Phaser phaser;
        public Position position;

        public bool isEngineUsable { get; internal set; }
        public bool isPhaserUsable { get; internal set; }

        public int shipEnergyReserve { get; internal set; }
        public int shipWeaponsPhaser { get; internal set; }
        public int shipWeaponsPhoton { get; internal set; }
        public int shipEngines { get; internal set; }

        public const int shipEnergyReserveMax = 80000;


        public Ship()
        {
            shield = new Shield();
            phaser = new Phaser();

            shipEnergyReserve = shipEnergyReserveMax;
        }

        public void TransferEnergyToShield(int energyToTransfer)
        {
            if (energyToTransfer < 0)
            {
                ArgumentException exception = new ArgumentException();
                throw exception;
            }

            if (SufficientEnergyToTransferToShield(energyToTransfer))
            {
                DebitEnergyFromReserve(energyToTransfer);
            }
        }

        public bool SufficientEnergyToTransferToShield(int amountOfEnergy)
        {
            return shipEnergyReserve >= amountOfEnergy ? true : false;
        }

        private void DebitEnergyFromReserve(int debitEnergy)
        {
            int estimatedCostOfEnergy = shield.Energy + debitEnergy;

            if (estimatedCostOfEnergy > Shield.EnergyMax)
            {
                // give ship back excess energy
                shipEnergyReserve += (estimatedCostOfEnergy - Shield.EnergyMax);
                shield.Energy = Shield.EnergyMax;
            }
            else
            {
                shield.Energy += debitEnergy;
                shipEnergyReserve -= debitEnergy;
            }
        }

        public void DamageShield(int shieldDamage)
        {
            // For every 500 units of damage = 1 star date to repair

        }
    }

    public struct Position
    {
        public int x;
        public int y;
    }

}