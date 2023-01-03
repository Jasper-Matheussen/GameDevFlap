using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.Collision.CollisionEvents;

public class CollectEvent : CollideWithEvent
{
    private readonly bool _isDiamond;
    public CollectEvent(Block block, bool isdiamond) : base(block)
    {
        _isDiamond = isdiamond;
    }
    public override void Execute(Hero hero)
    {
        Currentblock.BoundingBox = new Rectangle(0, 0, 0, 0);
        if (_isDiamond)
        {
            hero.Coins++;
            Game1.SoundManager.Play(Sounds.Collect);
        }
        else
        {
            Game1.SoundManager.Play(Sounds.Heart);
            hero.Health++;
        }
    }
}