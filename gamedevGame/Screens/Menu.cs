using gamedevGame.Characters;

namespace gamedevGame.Screens;

public class Menu : Screen
{
    public static bool StartGame { get; set; } = false;
    private readonly GraphicsDeviceManager _graphics;
    private Hero _hero;
    private Color colorMuteButton = Color.Green;
    private bool MuteClicked;

    public Menu(ContentManager content, GraphicsDeviceManager graphics, Hero hero) : base(content, graphics)
    {
        _hero = hero;
        hero.Speed = Vector2.Zero;
        Graphics.PreferredBackBufferHeight = 600;
        Graphics.PreferredBackBufferWidth = 600;
        Graphics.ApplyChanges();
        _graphics = graphics;
    }

    public override void Update(GameTime gameTime)
    {
        _hero.Position = new Vector2(270, 150);
        base.Update(gameTime);
        _hero.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        _hero.Draw(spriteBatch);
        spriteBatch.Draw(MenuSprite, PlayButtonPosition, PlayButton, Color.LightBlue);
        spriteBatch.Draw(MenuSprite, QuitButtonPosition, QuitButton, Color.Red);
        spriteBatch.Draw(MenuSprite, MuteButtonPosition, MuteButton, colorMuteButton);
    }

    protected override void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (PlayButtonPosition.Contains(mouseState.Position))
            {
                StartGame = true;
                Graphics.PreferredBackBufferWidth = 1150;
                Graphics.PreferredBackBufferHeight = 750;
                _graphics.ApplyChanges();
                _hero.Position = new Vector2(150, 200);
                _hero.Speed = new Vector2(2, 1);
                _hero.GravityPull = new Vector2(1, 1);
            }
            if (QuitButtonPosition.Contains(mouseState.Position))
            {
                Environment.Exit(0);
            }

            if (MuteButtonPosition.Contains(mouseState.Position))
            {
                if (colorMuteButton == Color.Green && !MuteClicked)
                {
                    colorMuteButton = Color.Red;
                    MediaPlayer.Pause();
                    MuteClicked = true;
                }
                else if (!MuteClicked)
                {
                    MediaPlayer.Resume();
                    colorMuteButton = Color.Green;
                    MuteClicked = true;
                }
                
            }
            
        }
        else
        {
            MuteClicked = false;
        }
    }
}