using gamedevGame.Sound;
using gamedevGame.SreenSelections;

namespace gamedevGame;
public class Game1 : Game
{
    private SpriteBatch _spriteBatch;

    private ScreenSelector _screenSelector;
    private readonly GraphicsDeviceManager _graphics;
    public static ContentManager content { get; set; }

    public static SoundManager SoundManager;
    
    public Game1()
    {
        content = Content;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = false; //veranderen naar True voor full screen
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        InitializeGameObjects();
        SoundManager.PlayThemeSong(); 
    }

    private void InitializeGameObjects()
    {
        SoundManager = new SoundManager();
        _screenSelector = new ScreenSelector(Content, _graphics);
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

