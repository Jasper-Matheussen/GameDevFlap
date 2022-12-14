using System;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.LevelDesign
{
	public class BlockFactory
	{

        public static Block CreateBlock(
        int type, int x, int y, Texture2D tilesetTexture)
        {
            Block newBlock = null;
          
            if (type == 1)
            {
                newBlock = new Block(x, y, tilesetTexture);
                
            }
            else if (type == 2)
            {
                newBlock = new Spike(x, y, tilesetTexture, false);
            }
            else if (type == -2)
            {
                newBlock = new Spike(x, y, tilesetTexture, true);
            }
            else if (type == 3)
            {
                newBlock = new House(x, y, tilesetTexture);
            }
            else if (type == 4)
            {
                newBlock = new Block(x, y, tilesetTexture, true);
            }
            else if (type == 5)
            {
                newBlock = new BackgroundBlock(x,y, tilesetTexture);
            }
 
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

}

