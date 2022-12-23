using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.SreenSelections;

namespace gamedevGame.Screens;

public class GameOver : Screen
{
    public GameOver(ContentManager content) : base(content)
    {
    }

    public override void Draw(SpriteBatch sprite)
    {
        sprite.DrawString(Font, "Game Over", new Vector2(475,200), Color.White);
        sprite.Draw(MenuSprite, MenuButtonPosition, MenuButton, Color.LightBlue);
        sprite.Draw(MenuSprite, QuitButtonPosition = new Rectangle(475, 340, 400 / 2, 100 / 2), QuitButton, Color.Red);
    }
    
    protected override void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (MenuButtonPosition.Contains(mouseState.Position))
            {
                Menu.StartGame = false;
                ScreenSelector.Hero.GameOver();
                ScreenSelector.LevelCreator.Reset();
                ScreenSelector.GameState = GameState.Menu;
            }
            if (QuitButtonPosition.Contains(mouseState.Position))
            {
                Environment.Exit(0);
            }
        }
    }
}