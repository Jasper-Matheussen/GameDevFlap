using gamedevGame.Collision;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.CollisionEvents;

public class CollectEvent : CollideWithEvent
{
    public CollectEvent(Block block) : base(block)
    {
    }
    public override void Execute(Hero hero)
    {
        _currentblock.BoundingBox = new Rectangle(0, 0, 0, 0);
        hero.Coins++;
    }
}