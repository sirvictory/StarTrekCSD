using System;
using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Ship
    {
        public struct Position
        {
            public int x;
            public int y;
        }

        public Phaser phaser;
        public Position position;
        Shield shield;
        public bool isEngineUsable { get; internal set; }
        public bool isPhaserUsable { get; internal set; }

        public int shipEnergy { get; internal set; }
        public int shipWeaponsPhaser { get; internal set; }
        public int shipWeaponsPhoton { get; internal set; }
        public int shipEngines { get; internal set; }

        public Ship()
        {
            shield = new Shield();
            phaser = new Phaser();
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
}
