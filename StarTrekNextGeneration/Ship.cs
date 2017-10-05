using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class Ship
    {
        public Shield shield;
        public Phaser phaser;
        public Position position;

        public Ship()
        {
            shield = new Shield();
            phaser = new Phaser();
        }
    }

    public struct Position
    {
        public int x;
        public int y;
    }

}