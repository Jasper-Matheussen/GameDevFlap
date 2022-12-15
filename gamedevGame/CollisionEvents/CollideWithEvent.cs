using System;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;

namespace gamedevGame.Collision
{
    public class CollideWithEvent
    {
        protected Block _currentblock;
        public CollideWithEvent(Block block)
        {
            _currentblock = block;
        }
        public virtual void Execute(Hero hero)
        {
            Console.WriteLine(hero.Coins);
        }
    }
}

