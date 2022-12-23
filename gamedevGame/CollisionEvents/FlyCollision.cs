using System;
using gamedevGame.Characters;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.CollisionEvents
{
	public class FlyCollision : CollideWithEvent
	{
		public override void Execute(Hero hero)
		{
			hero.Respawn();
            hero.Health -= 1;
		}

		public FlyCollision(Block block) : base(block)
		{
		}
	}
}

