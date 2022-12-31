using System;
using System.Reflection.Metadata;
using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.LevelDesign.Levels
{
	public class Level
	{
		public Vector2 HeroStartPosition { get; set; }
        public int[,] GameBoard { get; set; }
        public int[,] Backgroundboard { get; set; }
        public List<Block> Blocks { get; set; }
		public bool Done { get; set; } = false;
		public Hero Hero { get; set; }
		public List<Character> EnemyList { get; set; } = new List<Character>();
		public List<Block> BackgroundboardBlocks { get; set; }
		protected int DiamondCount { get; set; }
		public bool PortalSpawned { get; set; } = false;
		protected Texture2D Background;
		public bool SoundPlayed;
		private ContentManager _content;
		private Texture2D _heartsprite;

		protected Level(Hero hero, ContentManager content)
        {
			this.Hero = hero;
			_content = content;
			_heartsprite = content.Load<Texture2D>("heartSprite");
        }

		public void Update(GameTime gameTime)
		{
			NextLevelSound();
			DiamondCounter();
			HasCollided();
			EnemyCollided();
			ChildUpdate(gameTime);
			foreach (Character enemy in EnemyList)
			{
				enemy.Update(gameTime);
			}
		}
		
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			//Draw background
			foreach (var block in BackgroundboardBlocks.Where(block => block != null))
			{
				block.Draw(spriteBatch);
			}
			
			foreach (Block block in Blocks)
			{
				if (block != null && block.IsVisible)
				{
					block.Draw(spriteBatch);
				}
				else if(block != null && block.IsPortal && !block.IsVisible && PortalSpawned)
				{
					block.BoundingBox = new Rectangle(block.X, block.Y, 125, 110);
                    block.Draw(spriteBatch);
				}
			}
			Hero.Draw(spriteBatch);
			foreach (Character enemy in EnemyList)
			{
				enemy.Draw(spriteBatch);
			}
			
			DrawDiamondCounter(spriteBatch);
			DrawHearts(spriteBatch);
		}

		//TODO: Collider class gebruiken?
		private void HasCollided()
		{
			foreach (var block in Blocks)
			{
				if (block != null)
				{
                    if (Hero.Hitbox.Intersects(block.BoundingBox))
                    {
	                    if (block.IsPortal && block.BoundingBox.Contains(Hero.Hitbox))
	                    {
		                    Done = true;
	                    }
	                    block.IsCollidedWithEvent(Hero);
                    }
                }
			}
		}
		private void EnemyCollided()
		{
			foreach (var enemy in EnemyList.Where(enemy => enemy != null).Where(enemy => Hero.Hitbox.Intersects(enemy.Hitbox)))
			{
				Game1.SoundManager.Play(Sounds.Hurt);
				Hero.Position = HeroStartPosition;
				Hero.Health--;
			}
		}

		private void DiamondCounter()
		{
			DiamondCount = Hero.Coins;
			if (DiamondCount == 7)
			{
				PortalSpawned = true;
			}
		}
		
		private void DrawDiamondCounter(SpriteBatch spriteBatch)
		{
			//per diamond collected draw a small diamond in the top right corner
			var tileset = _content.Load<Texture2D>("tilemapNew");
			var tile = new Rectangle(380, 180, 17, 37);
			for (int i = 0; i < DiamondCount; i++)
			{
				spriteBatch.Draw(tileset, new Vector2(1000 + i * 20, 10), tile, Color.White);
			}
		}
		
		private void DrawHearts(SpriteBatch batch)
		{
			for (int i = 0; i < Hero.Health; i++)
			{
				batch.Draw(_heartsprite, new Vector2(10 + i * 16, 10), new Rectangle(0, 0, 16, 15), Color.White);
			}
		}
		
		protected virtual void ChildUpdate(GameTime gameTime)
		{
			
		}

		protected void NextLevelSound()
		{
			if (!SoundPlayed && PortalSpawned)
			{
				Game1.SoundManager.Play(Sounds.Next);
				SoundPlayed = true;
			}
		}
	}
}

