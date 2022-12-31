using gamedevGame.Characters;
using gamedevGame.Input;
using gamedevGame.interfaces;
using gamedevGame.LevelDesign;
using gamedevGame.Screens;
using gamedevGame.Sound;

namespace gamedevGame.SreenSelections;

public enum GameState { Menu, GameOver, Win, Playing };

public class ScreenSelector : IGameObject
{
    public static GameState GameState { get; set; }
    public static Hero Hero { get; set; }
    public static LevelCreator LevelCreator;
    private Menu _menu;
    private EndGame _endGame;
    private bool _ispause;

    public ScreenSelector(ContentManager content, GraphicsDeviceManager grahics)
    {
        Hero = new Hero(new KeyBoardReader(), content);
        _menu = new Menu(content, grahics, Hero);
        _endGame = new EndGame(content, grahics);
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
                MediaPlayer.IsMuted = false;
                _menu.Update(gameTime);
                if (Menu.StartGame)
                {
                    GameState = GameState.Playing;
                }
                break;
            case GameState.Win:
                _endGame.Update(gameTime);
                break;
            case GameState.GameOver:
                MediaPlayer.IsMuted = true;
                _endGame.Update(gameTime);
                break;
            case GameState.Playing:
                if (!_ispause)
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
                _endGame.Draw(sprite);
                break;
            case GameState.GameOver:
                _endGame.Draw(sprite);
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
            _ispause = true;
        }
        if (keyboardState.IsKeyDown(Keys.O) || keyboardState.IsKeyDown(Keys.Space))
        {
            _ispause = false;
        }
    }

    private void DetectGameOver()
    {
        if (Hero.IsDead)
        {
            GameState = GameState.GameOver;
            Hero.IsDead = false;
            PlayGameOverSound();
        }
    }

    private static void PlayGameOverSound()
    {
        Game1.SoundManager.Play(Sounds.GameOver);
    }

}