using System;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
namespace gamedevGame.CollisionEvents
{
	public class FlyCollision : CollideWithEvent
	{
        Vector2 newPosition;

		public override void Execute(Hero hero)
		{
            newPosition = new Vector2(50, 150);
            hero.Position = newPosition;
            hero.health -= 1;
            Console.WriteLine(hero.health);
        }
	}
}

