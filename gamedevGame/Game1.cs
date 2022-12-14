
using gamedevGame.Input;
using gamedevGame.LevelDesign;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

namespace gamedevGame;
public class Game1 : Game
{
    private SpriteBatch _spriteBatch;

    private Hero _hero; 
    private LevelCreator _testlevel;

    public Game1()
    {
        var graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        graphics.IsFullScreen = false; //veranderen naar True voor full screen
        graphics.PreferredBackBufferWidth = 1150;
        graphics.PreferredBackBufferHeight = 750;

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        InitializeGameObjects();
    }

    private void InitializeGameObjects()
    {
        _hero = new Hero(new KeyBoardReader(), Content);
        _testlevel = new LevelCreator(_hero, Content);
        _testlevel.CreateBlocks();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _hero.Update(gameTime);
        _testlevel.Update(gameTime);
        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        _hero.Draw(_spriteBatch);
        _testlevel.Draw(_spriteBatch);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

