using System;

namespace gamedevGame.LevelDesign.LevelBlocks
{
    public class Spike : Block
    {
        public Spike(int x, int y, Texture2D tilesetTexture) : base(x, y, tilesetTexture)
        {
            BoundingBox = new Rectangle(x, y, 60, 70);
            Passable = false;
            Texture = tilesetTexture;
            tile = new Rectangle(227, 70, 80, 70);
        }
    }
}

