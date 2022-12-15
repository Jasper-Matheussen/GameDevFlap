using System;
using gamedevGame.CollisionEvents;
using gamedevGame.LevelDesign.Levels;

namespace gamedevGame.LevelDesign.LevelBlocks
{
    public class House : Block
    {
        public House(int x, int y, Texture2D tilesetTexture) : base(x, y, tilesetTexture)
        {
            IsVisible = false;
            IsPortal = true;
            //BoundingBox = new Rectangle(x, y, 125, 110);
            X = x;
            Y = y;
            BoundingBox = new Rectangle(0, 0, 0, 0);
            Passable = false;
            Texture = tilesetTexture;
            Tile = new Rectangle(5, 215, 125, 110);
            CollideWithEvent = new NoEvent(this);
        }
    }
}

