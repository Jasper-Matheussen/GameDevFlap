
using gamedevGame.Input;
using gamedevGame.LevelDesign;
using gamedevGame.SreenSelections;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

namespace gamedevGame;
public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    
    private ScreenSelector _screenSelector;
    GraphicsDeviceManager graphics;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        graphics.IsFullScreen = false; //veranderen naar True voor full screen
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
        _screenSelector = new ScreenSelector(Content, graphics);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _screenSelector.Update(gameTime);
        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Gray);
        _spriteBatch.Begin();
        
        _screenSelector.Draw(_spriteBatch);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

