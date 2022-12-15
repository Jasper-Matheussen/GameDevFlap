using gamedevGame.Collision;
using gamedevGame.CollisionEvents;

namespace gamedevGame.LevelDesign.LevelBlocks;

public class Diamond : Block
{
    public Diamond(int x, int y, Texture2D tilesetTexture) : base(x, y, tilesetTexture)
    {
        Tile = new Rectangle(380, 180, 17, 37);
        BoundingBox = new Rectangle(x, y, 17, 37);
        Passable = false;
        Texture = tilesetTexture;
        CollideWithEvent = new CollectEvent(this);
    }
}