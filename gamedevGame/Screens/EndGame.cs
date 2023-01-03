using gamedevGame.Screens.Buttons;
using gamedevGame.SreenSelections;

namespace gamedevGame.Screens;

public class EndGame : Screen
{
    private ExitButton _exitButton;
    public EndGame(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
    {
        _exitButton = new ExitButton(QuitButton, QuitButtonPosition, content, Color.Red);
    }
    public override void Draw(SpriteBatch sprite)
    {
        SelectGameText(sprite);
        QuitButtonPosition = new Rectangle(475, 340, 400 / 2, 100 / 2);
        _exitButton.DrawGameOverExitButton(sprite, QuitButtonPosition);
    }

    private void SelectGameText(SpriteBatch sprite)
    {
        switch (ScreenSelector.GameState)
        {
            case GameState.GameOver:
                sprite.DrawString(Font, "Game Over", new Vector2(470,200), Color.DarkRed);
                sprite.DrawString(TextFont, "Je bent verloren klik op enter om terug naar het menu te gaan", new Vector2(350,280), Color.White);
                break;
            case GameState.Win:
                sprite.DrawString(Font, "Victory!", new Vector2(505, 200), Color.DarkGreen);
                sprite.DrawString(TextFont, "Je bent gewonnen klik op enter om terug naar het menu te gaan", new Vector2(350,280), Color.White);
                break;
        }
    }
    
    protected override void HandleButtonClick()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Enter))
        {
            Menu.StartGame = false;
            ScreenSelector.Hero.GameOver();
            ScreenSelector.LevelManager.Reset();
            ScreenSelector.GameState = GameState.Menu;
            
            Graphics.PreferredBackBufferWidth = 600;
            Graphics.PreferredBackBufferHeight = 600;
            Graphics.ApplyChanges();
        }
        
        _exitButton.Update();
    }
}