using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.Collision.CollisionEvents
{
    public class CollideWithEvent
    {
        protected readonly Block Currentblock;
        public CollideWithEvent(Block block)
        {
            Currentblock = block;
        }
        public virtual void Execute(Hero hero)
        {
            Console.WriteLine(hero.Coins);
        }
    }
}

