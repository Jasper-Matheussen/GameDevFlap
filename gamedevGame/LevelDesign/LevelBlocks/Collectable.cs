using gamedevGame.Collision;
using gamedevGame.CollisionEvents;

namespace gamedevGame.LevelDesign.LevelBlocks;

public class Collectable : Block
{
    public Collectable(int x, int y, Texture2D tilesetTexture, bool isDiamond) : base(x, y, tilesetTexture)
    {
        if (isDiamond)
        {
            Tile = new Rectangle(380, 180, 17, 37);
            BoundingBox = new Rectangle(x, y, 17, 37);
            Passable = false;
            Texture = tilesetTexture;
        }
        else
        {
            Tile = new Rectangle(0, 0, 16, 15);
            BoundingBox = new Rectangle(x, y, 16, 15);
            Passable = false;
            Texture = Game1.content.Load<Texture2D>("heartSprite");
        }
        CollideWithEvent = new CollectEvent(this, isDiamond);
        
    }
}