using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.Collision.CollisionEvents;

public class CollectEvent : CollideWithEvent
{
    private bool _IsDiamond;
    public CollectEvent(Block block, bool Isdiamond) : base(block)
    {
        _IsDiamond = Isdiamond;
    }
    public override void Execute(Hero hero)
    {
        Currentblock.BoundingBox = new Rectangle(0, 0, 0, 0);
        if (_IsDiamond)
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