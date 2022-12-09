using System;
using System.Reflection.Metadata;
using gamedevGame.LevelDesign.Levels;
using static System.Reflection.Metadata.BlobBuilder;

namespace gamedevGame.LevelDesign
{
	public class LevelCreator
	{
        Level currentLevel;
        int currentLevelIndex = 0;

        Level1 level1;
        Level2 level2;

        Level[] allLevels = new Level[2];

        List<Block> blocks = new List<Block>();

        Texture2D tileset;

        int[,] Currentgameboard;

        public LevelCreator(Hero hero, ContentManager content)
		{
            level2 = new Level2(hero);
            level1 = new Level1(hero);

            currentLevel = level1;
            Currentgameboard = currentLevel.GameBoard;

            allLevels[0] = level1;
            allLevels[1] = level2;
            var Content = content;
            tileset = Content.Load<Texture2D>("tilemapNew");

        }

        public void CreateBlocks()
        {
            blocks.Clear();
            for (int l = 0; l < Currentgameboard.GetLength(0); l++)
            {
                for (int k = 0; k < Currentgameboard.GetLength(1); k++)
                {
                    blocks.Add(BlockFactory.CreateBlock(Currentgameboard[l, k], k*50, l*50, tileset));
                }
            }
            currentLevel.blocks = blocks;
            
        }

        public void Update()
        {
            currentLevel.Update();
            if (currentLevel.done)
            {
                nextLevel();
            }
            
        }

        private void nextLevel()
        {
            currentLevelIndex++;
            currentLevel = allLevels[currentLevelIndex];
            Currentgameboard = currentLevel.GameBoard;
            CreateBlocks();
        }

        //Loop thru the blocks in the list and draw them if they are not null.
        public void Draw(SpriteBatch batch)
        {
            foreach (var item in blocks)
            {
                if (item != null)
                {
                    item.Draw(batch);
                }
            }
        }

    }
}

