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


        public Ship()
        {
            shield = new Shield();
            phaser = new Phaser();

            shipEnergyReserve = 80000;
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

           if (estimatedCostOfEnergy > 10000)
           {
               // give ship back excess energy
               shipEnergyReserve += (estimatedCostOfEnergy - 10000);
               shield.Energy = 10000;
           }
           else
           {
               shield.Energy += debitEnergy;
               shipEnergyReserve -= debitEnergy;
           }
        }

        public void healEngine(int engineHealth)
        {
            shipEngines = engineHealth;
            if (shipEngines > 100)
            {
                shipEngines = 100;
            }


            isEngineUsable = true;
        }

        public void damageEngine(int engineDamage)
        {
            shipEngines -= engineDamage;
            if (shipEngines <= 0)
            {
                shipEngines = 0;
                isEngineUsable = false;
            }
            else
            {
                isEngineUsable = true;
            }
        }

        public void healPhaser(int phaserHealth)
        {
            shipWeaponsPhaser = phaserHealth;
            if (phaserHealth > 100)
            {
                phaserHealth = 100;
            }

            isPhaserUsable = true;
        }

        public void damagePhaser(int phaserDamage)
        {
            // For every 300 units of damage = 1 star date to repair
            shipWeaponsPhaser -= phaserDamage;
            if (shipWeaponsPhaser <= 0)
            {
                shipWeaponsPhaser = 0;
                isPhaserUsable = false;
            }
            else
            {
                isPhaserUsable = true;
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