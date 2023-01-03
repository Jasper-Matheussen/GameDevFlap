namespace gamedevGame.LevelDesign.LevelBlocks;

public abstract class BlockFactory
{

    public static Block CreateBlock(
        int type, int x, int y, Texture2D tilesetTexture)
    {
        Block newBlock = type switch
        {
            1 => new Block(x, y, tilesetTexture),
            2 => new Spike(x, y, tilesetTexture, false),
            -2 => new Spike(x, y, tilesetTexture, true),
            3 => new House(x, y, tilesetTexture),
            4 => new Block(x, y, tilesetTexture, BlockType.Platform),
            5 => new BackgroundBlock(x, y, tilesetTexture),
            6 => new Collectable(x, y, tilesetTexture, true),
            7 => new Block(x, y, tilesetTexture, BlockType.BlueBlock),
            8 => new Collectable(x, y, tilesetTexture, false),
            _ => null
        };

        return newBlock;
    }
    /* public static Block CreateBlock(
     string type, int x, int y, GraphicsDevice graphics)
     {
         Block newBlock = null;
         type = type.ToUpper();
         if (type == "NORMAL")
         {
             newBlock = new Block(x, y, graphics);
             
         }

         return newBlock;
     }*/

}