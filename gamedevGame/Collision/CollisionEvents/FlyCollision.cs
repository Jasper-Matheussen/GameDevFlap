using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.Collision.CollisionEvents;

public class FlyCollision : CollideWithEvent
{
	public override void Execute(Hero hero)
	{
		if (hero.IsCollidingWithBlock) return;
		Game1.SoundManager.Play(Sounds.Hurt);
		hero.Respawn();
		hero.Health--;
		hero.IsCollidingWithBlock = true;


	}

	public FlyCollision(Block block) : base(block)
	{
	}
}