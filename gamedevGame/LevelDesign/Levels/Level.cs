using gamedevGame.Characters;
using gamedevGame.Collision;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.LevelDesign.Levels;

public abstract class Level : ILevel
{
	#region Fields
		
	protected Texture2D Background;
	public bool SoundPlayed;
	private readonly ContentManager _content;
	private readonly Texture2D _heartsprite;

	#endregion
		
	protected Level(Hero hero, ContentManager content)
	{
		Hero = hero;
		_content = content;
		_heartsprite = content.Load<Texture2D>("heartSprite");
	}
		
	#region Properties
		
	public Vector2 HeroStartPosition { get; set; }
	public int[,] GameBoard { get; init; }
	public int[,] Backgroundboard { get; set; }
	public List<Block> Blocks { get; set; }
	public bool Done { get; set; }
	public Hero Hero { get; }
	public List<Character> EnemyList { get; } = new();
	public List<Block> BackgroundboardBlocks { get; set; }
	private int DiamondCount { get; set; }
	public bool PortalSpawned { get; set; }

	#endregion
		

	#region Update logic

	public void Update(GameTime gameTime)
	{
		NextLevelSound();
		DiamondCounter();
			
		//Collision detection
		UpdateCollision();

		UpdateEnemys(gameTime);
	}
		
	private void UpdateCollision()
	{
		//Collision detection
		Done = Collider.HasCollidedWithBlock(Blocks, Hero);
		Collider.EnemyCollided(EnemyList, Hero, HeroStartPosition);
	}

	private void UpdateEnemys(GameTime gameTime)
	{
		foreach (Character enemy in EnemyList)
		{
			enemy.Update(gameTime);
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

	private void NextLevelSound()
	{
		if (!SoundPlayed && PortalSpawned)
		{
			Game1.SoundManager.Play(Sounds.Next);
			SoundPlayed = true;
		}
	}

	#endregion
		

	#region Draw logic

	public virtual void Draw(SpriteBatch spriteBatch)
	{
		DrawBlocks(spriteBatch);
		Hero.Draw(spriteBatch);
		DrawEnemys(spriteBatch);
		DrawDiamondCounter(spriteBatch);
		DrawHearts(spriteBatch);
	}

	private void DrawEnemys(SpriteBatch spriteBatch)
	{
		foreach (Character enemy in EnemyList)
		{
			enemy.Draw(spriteBatch);
		}
	}
		
	private void DrawBlocks(SpriteBatch spriteBatch)
	{
		//Draw background
		foreach (var block in BackgroundboardBlocks.Where(block => block != null))
		{
			block.Draw(spriteBatch);
		}
			
		//Draw foreground blocks
		foreach (Block block in Blocks)
		{
			if (block is { IsVisible: true })
			{
				block.Draw(spriteBatch);
			}
			else if(block is { IsPortal: true, IsVisible: false } && PortalSpawned)
			{
				block.BoundingBox = new Rectangle(block.X, block.Y, 125, 110);
				block.Draw(spriteBatch);
			}
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
	#endregion
		
}