using System;
namespace gamedevGame.Collision
{
    public class CollideWithEvent
    {
        public CollideWithEvent()
        {
        }

        public virtual void Execute(Hero hero)
        {
            Console.WriteLine(hero.Health);
        }
    }
}

