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

        public Level(Hero hero)
        {
			this.Hero = hero;
        }

		public void Update()
		{
			HasCollided();
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

