using gamedevGame.Characters;
using gamedevGame.Screens.Buttons;

namespace gamedevGame.Screens;

public class Menu : Screen
{
    public static bool StartGame { get; set; }
    private readonly Hero _hero;
    private readonly List<Button> _buttons = new();

    public Menu(ContentManager content, GraphicsDeviceManager graphics, Hero hero) : base(content, graphics)
    {
        _hero = hero;
        hero.Speed = Vector2.Zero;
        Graphics.PreferredBackBufferHeight = 600;
        Graphics.PreferredBackBufferWidth = 600;
        Graphics.ApplyChanges();
        _buttons.Add(new ExitButton(QuitButton, QuitButtonPosition, content, Color.Red));
        _buttons.Add(new PlayButton(PlayButton, PlayButtonPosition, content, Color.LightBlue, hero, graphics));
        _buttons.Add(new MuteButton(MuteButton, MuteButtonPosition, content, Color.Green));
    }

    public override void Update(GameTime gameTime)
    {
        _hero.Position = new Vector2(270, 150);
        base.Update(gameTime);
        _hero.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        _hero.Draw(spriteBatch);
    }

    protected override void HandleButtonClick()
    {
        foreach (var button in _buttons)
        {
            button.Update();
        }
    }
    
    protected override void HandleButtonClick(SpriteBatch spriteBatch)
    {
        foreach (var button in _buttons)
        {
            button.Draw(spriteBatch);
        }
    }
}