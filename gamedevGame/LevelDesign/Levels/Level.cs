using System;
using System.Reflection.Metadata;

namespace gamedevGame.LevelDesign.Levels
{
	public class Level
	{
        public int[,] GameBoard { get; set; }
        public int[,] Backgroundboard { get; set; }
        public List<Block> Blocks { get; set; }
		public bool Done { get; set; } = false;
		public Hero Hero { get; set; }
		public List<Character> EnemyList { get; set; } = new List<Character>();
		public List<Block> BackgroundboardBlocks { get; set; }
		protected int DiamondCount { get; set; }

		private ContentManager _content;
		
		public Level(Hero hero, ContentManager content)
        {
			this.Hero = hero;
			_content = content;
        }

		public void Update(GameTime gameTime)
		{
			DiamondCounter();
			HasCollided();
			foreach (Character enemy in EnemyList)
			{
				enemy.Update(gameTime);
			}
		}
		
		public void Draw(SpriteBatch spriteBatch)
		{
			//Draw background
			foreach (Block block in BackgroundboardBlocks)
			{
				block.Draw(spriteBatch);
			}
			
			foreach (Block block in Blocks)
			{
				if (block != null)
				{
					block.Draw(spriteBatch);	
				}
				
			}
			Hero.Draw(spriteBatch);
			foreach (Character enemy in EnemyList)
			{
				enemy.Draw(spriteBatch);
			}
			
			DrawDiamondCounter(spriteBatch);
		}

		private bool HasCollided()
		{
			foreach (var block in Blocks)
			{
				if (block != null)
				{
                    if (Hero.Hitbox.Intersects(block.BoundingBox))
                    {
						block.IsCollidedWithEvent(Hero);
                        return true;
                    }
                }
			}
            return false;
        }

		private void DiamondCounter()
		{
			DiamondCount = Hero.Coins;
			if (DiamondCount == 7)
			{
				Done = false;
			}
		}
		
		private void DrawDiamondCounter(SpriteBatch spriteBatch)
		{
			//per diamond collected draw a small diamond in the top right corner
			var _tileset = _content.Load<Texture2D>("tilemapNew");
			var tile = new Rectangle(380, 180, 17, 37);
			for (int i = 0; i < DiamondCount; i++)
			{
				spriteBatch.Draw(_tileset, new Vector2(1000 + i * 20, 10), tile, Color.White);
			}
		}
		
	}
}

