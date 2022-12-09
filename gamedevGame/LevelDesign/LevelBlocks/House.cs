using System;
using gamedevGame.CollisionEvents;

namespace gamedevGame.LevelDesign.LevelBlocks
{
    public class House : Block
    {
        public House(int x, int y, Texture2D tilesetTexture) : base(x, y, tilesetTexture)
        {
            BoundingBox = new Rectangle(x, y, 125, 110);
            Passable = false;
            Texture = tilesetTexture;
            tile = new Rectangle(5, 215, 125, 110);
            CollideWithEvent = new NoEvent();
        }
    }
}

