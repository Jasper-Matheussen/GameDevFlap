using gamedevGame.interfaces;

namespace gamedevGame.Menu_s;

public class Menu : IGameObject
{
    public bool startGame = false;
    private GraphicsDeviceManager graphics;
    private Hero _hero;
    
    private Texture2D _menuSprite;
    private Rectangle _playButton = new Rectangle(0,0, 600,200);
    private Rectangle _playButtonPosition = new Rectangle(200, 200, 400 / 2, 100 / 2);
    private Rectangle _quitButton = new Rectangle(600,620, 610,206);
    private Rectangle _quitButtonPosition = new Rectangle(200, 270, 400 / 2, 100 / 2);
    public Menu(ContentManager content, GraphicsDeviceManager graphics, Hero hero)
    {
        _hero = hero;
        hero.Speed = Vector2.Zero;
        graphics.PreferredBackBufferHeight = 600;
        graphics.PreferredBackBufferWidth = 600;
        graphics.ApplyChanges();
        this.graphics = graphics;
        _menuSprite = content.Load<Texture2D>("Menu");
    }

    public void Update(GameTime gameTime)
    {
        _hero.Position = new Vector2(270, 150);
        HandleButtonClick();
        _hero.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _hero.Draw(spriteBatch);
        spriteBatch.Draw(_menuSprite, _playButtonPosition, _playButton, Color.LightBlue);
        spriteBatch.Draw(_menuSprite, _quitButtonPosition, _quitButton, Color.LightBlue);
    }
    
    public void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (_playButtonPosition.Contains(mouseState.Position))
            {
                startGame = true;
                graphics.ApplyChanges();
                _hero.Position = new Vector2(150, 200);
                _hero.Speed = new Vector2(2, 1);
                _hero.GravityPull = new Vector2(1, 1);
            }
            if (_quitButtonPosition.Contains(mouseState.Position))
            {
                Environment.Exit(0);
            }
        }
    }
}