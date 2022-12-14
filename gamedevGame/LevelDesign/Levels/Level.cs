using System;
using System.Reflection.Metadata;

namespace gamedevGame.LevelDesign.Levels
{
	public class Level
	{
        public int[,] GameBoard { get; set; }
        public List<Block> Blocks { get; set; }
		public bool Done { get; set; } = false;
		public Hero Hero { get; set; }
		public List<Character> EnemyList { get; set; } = new List<Character>();

        public Level(Hero hero, ContentManager content)
        {
			this.Hero = hero;
        }

		public void Update(GameTime gameTime)
		{
			HasCollided();
			foreach (Character enemy in EnemyList)
			{
				enemy.Update(gameTime);
			}
		}
		
		public void Draw(SpriteBatch spriteBatch)
		{
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
	}
}

