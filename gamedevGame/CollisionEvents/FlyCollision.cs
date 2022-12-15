using System;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;

namespace gamedevGame.CollisionEvents
{
	public class FlyCollision : CollideWithEvent
	{
        private Vector2 _newPosition;

		public override void Execute(Hero hero)
		{
            _newPosition = new Vector2(150, 200);
            hero.Position = _newPosition;
            hero.Health -= 1;
            Console.WriteLine(hero.Health);
        }

		public FlyCollision(Block block) : base(block)
		{
		}
	}
}

