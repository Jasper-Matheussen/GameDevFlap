using System;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;

namespace gamedevGame.CollisionEvents
{
	public class NoEvent : CollideWithEvent
	{
		public NoEvent(Block block) : base(block)
		{
		}
	}
}

