using System;
using System.Reflection.Metadata;

namespace gamedevGame.LevelDesign.Levels
{
	public class Level
	{
        public int[,] GameBoard { get; set; }
        public List<Block> blocks { get; set; }
		public bool done { get; set; } = false;
		public Hero hero { get; set; }

        public Level(Hero hero)
        {
			this.hero = hero;
        }

		public void Update()
		{
			HasCollided();
		}

		private bool HasCollided()
		{
			foreach (var block in blocks)
			{
				if (block != null)
				{
                    if (hero.hitbox.Intersects(block.BoundingBox))
                    {
						block.IsCollidedWithEvent(hero);
                        return true;
                    }
                }
			}
            return false;
        }
	}
}

