using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.Collision.CollisionEvents
{
	public class FlyCollision : CollideWithEvent
	{
		public override void Execute(Hero hero)
		{
            Game1.SoundManager.Play(Sounds.Hurt);
            hero.Respawn();
            hero.Health -= 1;
        }

		public FlyCollision(Block block) : base(block)
		{
		}
	}
}

