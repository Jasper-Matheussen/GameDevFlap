using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.LevelDesign.Levels;

namespace gamedevGame.LevelDesign
{
	public class LevelCreator
	{
        private Level _currentLevel;

        private readonly List<Block> _blocks = new();
        private readonly List<Block> _backgroundBlocks = new();

        private readonly Texture2D _tileset;
        
        public int[,] Currentgameboard { get; set; }


        public LevelCreator(Level[] allLevels, ContentManager content, GraphicsDeviceManager graphics)
		{
            graphics.PreferredBackBufferWidth = 1150;
            graphics.PreferredBackBufferHeight = 750;
            
            _currentLevel = allLevels[0];
            Currentgameboard = _currentLevel.GameBoard;
            
            _tileset = content.Load<Texture2D>("tilemapNew");
        }

        public void CreateBlocks(Level level)
        {
            _currentLevel = level;
            Currentgameboard = _currentLevel.GameBoard;

            _backgroundBlocks.Clear();
            for (int l = 0; l < _currentLevel.Backgroundboard.GetLength(0); l++)
            {
                for (int k = 0; k < _currentLevel.Backgroundboard.GetLength(1); k++)
                {
                    _backgroundBlocks.Add(BlockFactory.CreateBlock(_currentLevel.Backgroundboard[l, k], k*50, l*50, _tileset));
                }
            }
            _currentLevel.BackgroundboardBlocks = _backgroundBlocks;
            
            _blocks.Clear();
            for (int l = 0; l < Currentgameboard.GetLength(0); l++)
            {
                for (int k = 0; k < Currentgameboard.GetLength(1); k++)
                {
                    _blocks.Add(BlockFactory.CreateBlock(Currentgameboard[l, k], k*50, l*50, _tileset));
                }
            }
            _currentLevel.Blocks = _blocks;
        }
        
        //Loop thru the blocks in the list and draw them if they are not null.
        public void Draw(SpriteBatch batch)
        {
            _currentLevel.Draw(batch);
        }

    }
}

