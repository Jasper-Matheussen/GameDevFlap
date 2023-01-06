using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.Collision.CollisionEvents;

public class CollideWithEvent
{
    protected readonly Block Currentblock;

    protected CollideWithEvent(Block block)
    {
        Currentblock = block;
    }
    public virtual void Execute(Hero hero)
    {
    }
}