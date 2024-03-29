using gamedevGame.interfaces;

namespace gamedevGame.Screens;

public class Screen : IGameObject
{
    protected readonly Texture2D MenuSprite;
    protected readonly SpriteFont Font;
    protected readonly SpriteFont TextFont;
    
    protected Rectangle PlayButton = new(0,0, 600,200);
    protected Rectangle PlayButtonPosition = new(200, 200, 400 / 2, 100 / 2);
    
    protected Rectangle QuitButton = new(600,620, 610,206);
    protected Rectangle QuitButtonPosition = new(200, 270, 400 / 2, 100 / 2);

    protected Rectangle MuteButton = new(1820, 620, 200, 195);
    protected Rectangle MuteButtonPosition = new(540, 10, 50, 50);

    protected readonly GraphicsDeviceManager Graphics;
    
    protected Screen(ContentManager content, GraphicsDeviceManager graphics)
    {
        Graphics = graphics;
        MenuSprite = content.Load<Texture2D>("Menu");
        Font = content.Load<SpriteFont>("font");
        TextFont = content.Load<SpriteFont>("textfont");
    }
    
    public virtual void Update(GameTime gameTime)
    {
        HandleButtonClick();
    }

    public virtual void Draw(SpriteBatch sprite)
    {
        HandleButtonClick(sprite);
    }
    
    protected virtual void HandleButtonClick()
    {
    }
    protected virtual void HandleButtonClick(SpriteBatch sprite)
    {
    }
}