namespace gamedevGame.LevelDesign.LevelBlocks;

public class Spike : Block
{
    public Spike(int x, int y, Texture2D tilesetTexture, bool isfacingup) : base(x, y, tilesetTexture)
    {
        if (isfacingup)
        {
            Tile = new Rectangle(151, 70, 70, 70);
            BoundingBox = new Rectangle(x, y, 50, 60);
        }
        else
        {
            Tile = new Rectangle(227, 70, 80, 70);
            BoundingBox = new Rectangle(x, y, 60, 70);
        }
        Passable = false;
        Texture = tilesetTexture;
    }
}