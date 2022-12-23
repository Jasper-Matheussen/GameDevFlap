using System;
using gamedevGame.Characters;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.LevelDesign.Levels;

namespace gamedevGame.Collision
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

