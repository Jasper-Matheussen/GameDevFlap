using System;
using gamedevGame.Characters;
using gamedevGame.SreenSelections;

namespace gamedevGame.LevelDesign.Levels
{
	public class Level2 : Level
	{
		public Level2(Hero hero, ContentManager content) : base(hero, content)
		{
			var enemy1 = new ShittingBird(content, new Vector2(45, 100), new Vector2(1050, 100),
				new Vector2(2.5f, 0), Color.White);
	        EnemyList.Add(enemy1);
	        enemy1 = new ShittingBird(content, new Vector2(550, 350), new Vector2(1050, 350),
		        new Vector2(1,0), Color.Orange);
	        EnemyList.Add(enemy1);
	        enemy1 = new ShittingBird(content, new Vector2(45, 300), new Vector2(350, 300),
		        new Vector2(1,0), Color.Aqua);
	        EnemyList.Add(enemy1);
	        enemy1 = new ShittingBird(content, new Vector2(650, 550), new Vector2(1050, 500),
		        new Vector2(3,0), Color.DarkGray);
	        EnemyList.Add(enemy1);
	        
            GameBoard = new int[,]
           {
                { 7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7 },
                { 7,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7 },
                { 7,0,0,0,7,0,0,0,7,0,0,0,0,0,7,7,0,0,0,0,0,0,7 },
                { 7,0,0,7,0,7,0,0,0,0,6,0,0,7,7,7,7,0,6,0,0,0,7 },
                { 7,0,6,0,7,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,7 },
                { 7,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,7 },
                { 1,1,0,0,0,0,0,0,7,7,7,0,0,0,6,0,0,0,0,0,0,0,7 },
                { 1,1,1,0,0,0,0,0,7,0,7,7,0,0,0,0,0,0,7,0,6,0,7 },
                { 1,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,0,7 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,7 },
                { 1,0,0,0,0,0,0,0,0,0,0,7,7,0,6,0,0,0,0,0,0,0,7 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,3,0,0,0,0,7 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7 },
                { 1,1,1,1,1,4,0,4,0,4,0,4,0,4,0,4,0,4,0,4,0,4,0 }
           };
            Backgroundboard = new int[,]
            {
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
	            { 5,5,5,5,5,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7 }
            };
            
            HeroStartPosition = new Vector2(150, 550);
            Background = content.Load<Texture2D>("Background_2");
            
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Background, new Vector2(0, 0), Color.White);
			base.Draw(spriteBatch);
		}
		
		protected override void ChildUpdate(GameTime gameTime)
		{
			if (DiamondCount == 7) //TODO: Change to 7
			{
				PortalSpawned = true;
			}
		}
	}
}

