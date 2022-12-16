using gamedevGame.Input;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.Menu_s;

namespace gamedevGame.SreenSelections;

public enum GameState { Menu, GameOver, Win, Playing };

public class ScreenSelector : IGameObject
{
    public GameState GameState;
    private Hero _hero;
    private LevelCreator _levelCreator;
    private Menu _menu;
    private bool Ispause;

    public ScreenSelector(ContentManager content, GraphicsDeviceManager grahics)
    {
        _hero = new Hero(new KeyBoardReader(), content);
        _menu = new Menu(content, grahics, _hero);
        _levelCreator = new LevelCreator(_hero, content, grahics);
        _levelCreator.CreateBlocks();
        GameState = GameState.Menu;
    }
    
    public void Update(GameTime gameTime)
    {
        DetectPause();
        switch (GameState)
        {
            case GameState.Menu:
                _menu.Update(gameTime);
                if (_menu.startGame)
                {
                    GameState = GameState.Playing;
                }
                break;
            case GameState.Win:
                //Do win stuff
                break;
            case GameState.GameOver:
                //Do game over stuff
                break;
            case GameState.Playing:
                if (!Ispause)
                {
                    _hero.Update(gameTime);
                    _levelCreator.Update(gameTime);
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
                //Do game over stuff
                break;
            case GameState.Playing:
                _hero.Draw(sprite);
                _levelCreator.Draw(sprite);
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
}