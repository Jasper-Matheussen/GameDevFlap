using gamedevGame.Characters;

namespace gamedevGame.Screens.Buttons;

public class PlayButton : Button
{
    private readonly Hero _hero;
    private readonly GraphicsDeviceManager _graphics;

    public override void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (Position.Contains(mouseState.Position))
            {
                Menu.StartGame = true;
                _graphics.PreferredBackBufferWidth = 1150;
                _graphics.PreferredBackBufferHeight = 750;
                _graphics.ApplyChanges();
                
                SetHero();
                
            }
        }
    }

    private void SetHero()
    {
        _hero.Position = new Vector2(150, 200);
        _hero.Speed = new Vector2(2, 1);
        _hero.GravityPull = new Vector2(1, 1);
        _hero.RespawnPos = _hero.Position;
    }

    public PlayButton(Rectangle boundingBox, Rectangle position, ContentManager content, Color color, Hero hero, GraphicsDeviceManager graphics) : base(boundingBox, position, content, color)
    {
        _hero = hero;
        _graphics = graphics;
    }
}