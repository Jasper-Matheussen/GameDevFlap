using System;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
namespace gamedevGame.CollisionEvents
{
	public class FlyCollision : CollideWithEvent
	{
        private Vector2 _newPosition;

		public override void Execute(Hero hero)
		{
            _newPosition = new Vector2(50, 150);
            hero.Position = _newPosition;
            hero.Health -= 1;
            Console.WriteLine(hero.Health);
        }
	}
}

