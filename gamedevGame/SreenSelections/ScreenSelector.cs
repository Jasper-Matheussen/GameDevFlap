using gamedevGame.Characters;
using gamedevGame.Input;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.Screens;

namespace gamedevGame.SreenSelections;

public enum GameState { Menu, GameOver, Win, Playing };

public class ScreenSelector : IGameObject
{
    public static GameState GameState { get; set; }
    public static Hero Hero { get; set; }
    public static LevelCreator LevelCreator;
    private Menu _menu;
    private GameOver _gameOver;
    private bool Ispause;

    public ScreenSelector(ContentManager content, GraphicsDeviceManager grahics)
    {
        Hero = new Hero(new KeyBoardReader(), content);
        _menu = new Menu(content, grahics, Hero);
        _gameOver = new GameOver(content);
        LevelCreator = new LevelCreator(Hero, content, grahics);
        LevelCreator.CreateBlocks();
        GameState = GameState.Menu;
    }
    
    public void Update(GameTime gameTime)
    {
        DetectPause();
        DetectGameOver();
        switch (GameState)
        {
            case GameState.Menu:
                _menu.Update(gameTime);
                if (Menu.StartGame)
                {
                    Console.WriteLine("Start Game");
                    GameState = GameState.Playing;
                }
                break;
            case GameState.Win:
                //Do win stuff
                break;
            case GameState.GameOver:
                _gameOver.Update(gameTime);
                break;
            case GameState.Playing:
                if (!Ispause)
                {
                    Hero.Update(gameTime);
                    LevelCreator.Update(gameTime);
                }
               
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Draw(SpriteBatch sprite)
    {
        switch (GameState)
        {
            case GameState.Menu:
                _menu.Draw(sprite);
                break;
            case GameState.Win:
                //Do win stuff
                break;
            case GameState.GameOver:
                _gameOver.Draw(sprite);
                break;
            case GameState.Playing:
                Hero.Draw(sprite);
                LevelCreator.Draw(sprite);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void DetectPause()
    {
        //if keyboard P is pressed then pause
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.P))
        {
            Ispause = true;
        }
        if (keyboardState.IsKeyDown(Keys.O) || keyboardState.IsKeyDown(Keys.Space))
        {
            Ispause = false;
        }
    }

    private void DetectGameOver()
    {
        if (Hero.IsDead)
        {
            GameState = GameState.GameOver;
            Hero.IsDead = false;
        }
    }
}