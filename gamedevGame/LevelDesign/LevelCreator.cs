using System;
using System.Reflection.Metadata;
using gamedevGame.LevelDesign.Levels;
using static System.Reflection.Metadata.BlobBuilder;

namespace gamedevGame.LevelDesign
{
	public class LevelCreator
	{
        private Level _currentLevel;
        private int _currentLevelIndex = 0;

        private readonly Level[] _allLevels = new Level[2];

        private readonly List<Block> _blocks = new List<Block>();

        private readonly Texture2D _tileset;
        private readonly Texture2D _heartsprite;

        private int[,] _currentgameboard;

        public LevelCreator(Hero hero, ContentManager content)
		{
            var level1 = new Level1(hero);
            var level2 = new Level2(hero);

            _currentLevel = level1;
            _currentgameboard = _currentLevel.GameBoard;

            _allLevels[0] = level1;
            _allLevels[1] = level2;
            _tileset = content.Load<Texture2D>("tilemapNew");
            _heartsprite = content.Load<Texture2D>("heartSprite");

        }

        public void CreateBlocks()
        {
            _blocks.Clear();
            for (int l = 0; l < _currentgameboard.GetLength(0); l++)
            {
                for (int k = 0; k < _currentgameboard.GetLength(1); k++)
                {
                    _blocks.Add(BlockFactory.CreateBlock(_currentgameboard[l, k], k*50, l*50, _tileset));
                }
            }
            _currentLevel.Blocks = _blocks;
            
        }

        public void Update()
        {
            _currentLevel.Update();
            if (_currentLevel.Done)
            {
                NextLevel();
            }
            
        }
        
        //Loop thru the blocks in the list and draw them if they are not null.
        public void Draw(SpriteBatch batch)
        {
            foreach (var item in _blocks)
            {
                if (item != null)
                {
                    item.Draw(batch);
                }
            }
            DrawHearts(batch);
        }

        private void NextLevel()
        {
            _currentLevelIndex++;
            _currentLevel = _allLevels[_currentLevelIndex];
            _currentgameboard = _currentLevel.GameBoard;
            CreateBlocks();
        }

        private void DrawHearts(SpriteBatch batch)
        {
            for (int i = 0; i < _currentLevel.Hero.Health; i++)
            {
                batch.Draw(_heartsprite, new Vector2(i * 16, 0), new Rectangle(0, 0, 16, 15), Color.White);
            }
        }

    }
}

