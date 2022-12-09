
using gamedevGame.Input;
using gamedevGame.LevelDesign;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

namespace gamedevGame;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    Hero hero;
    Texture2D texture;

    //block
    Block testBlock;

    LevelCreator testlevel;

    //hitbox test
    Texture2D hitBoxHeroTexture;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = false; //veranderen naar True voor full screen
        _graphics.PreferredBackBufferWidth = 1150;
        _graphics.PreferredBackBufferHeight = 750;

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        texture = Content.Load<Texture2D>("spritesheet2");
        hitBoxHeroTexture = new Texture2D(GraphicsDevice, 1, 1);
        hitBoxHeroTexture.SetData(new[] { Color.White });

        //testBlock = BlockFactory.CreateBlock("normal", 300, 300, GraphicsDevice);
        InitializeGameObjects();

        // TODO: use this.Content to load your game content here
      
    }

    private void InitializeGameObjects()
    {
        hero = new Hero(texture, hitBoxHeroTexture, new KeyBoardReader(), testBlock);
        testlevel = new LevelCreator(hero, Content);
        testlevel.CreateBlocks();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        // TODO: Add your update logic here

        hero.Update(gameTime);
        testlevel.Update();
        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        hero.Draw(_spriteBatch);
        testlevel.Draw(_spriteBatch);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}

