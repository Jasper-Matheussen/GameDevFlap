using gamedevGame.interfaces;

namespace gamedevGame.Screens;

public class Screen : IGameObject
{
    protected readonly Texture2D MenuSprite;
    protected SpriteFont Font;
    protected SpriteFont TextFont;
    
    protected Rectangle PlayButton = new Rectangle(0,0, 600,200);
    protected Rectangle PlayButtonPosition = new Rectangle(200, 200, 400 / 2, 100 / 2);
    
    protected Rectangle QuitButton = new Rectangle(600,620, 610,206);
    protected Rectangle QuitButtonPosition = new Rectangle(200, 270, 400 / 2, 100 / 2);
    
    protected GraphicsDeviceManager Graphics;
    
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
    }
    
    protected virtual void HandleButtonClick()
    {
    }
}