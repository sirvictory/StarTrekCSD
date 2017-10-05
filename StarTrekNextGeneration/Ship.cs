using System;
using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Ship
    {
        Shield shield;
        public Shield shield;
        public Phaser phaser;
        public Position position;
        public bool isEngineUsable { get; internal set; }
        public bool isPhaserUsable { get; internal set; }

        public int shipEnergy { get; internal set; }
        public int shipWeaponsPhaser { get; internal set; }
        public int shipWeaponsPhoton { get; internal set; }
        public int shipEngines { get; internal set; }


        public Ship()
        {
            shield = new Shield();
            
            
        }

        public void healEngine(int engineHealth)
        {
            shipEngines = engineHealth;
            if(shipEngines > 100)
            {
                shipEngines = 100;
            }


            isEngineUsable = true;
        }

        public void damageEngine(int engineDamage)
        {
            shipEngines -= engineDamage;
            if(shipEngines <= 0)
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


    }

    public struct Position
    {
        public int x;
        public int y;
    }

}