using gamedevGame.CollisionEvents;

namespace gamedevGame.LevelDesign.LevelBlocks;

public class BackgroundBlock : Block
{
    public BackgroundBlock(int x, int y, Texture2D tilesetTexture) : base(x, y, tilesetTexture)
    {
        BoundingBox = new Rectangle(x, y, 50, 55);
        Passable = true;
        Texture = tilesetTexture;
        Tile = new Rectangle(5, 0, 50, 50);
        CollideWithEvent = new NoEvent();
    }
}