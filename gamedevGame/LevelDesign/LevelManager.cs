using gamedevGame.Characters;
using gamedevGame.LevelDesign.Levels;
using gamedevGame.Sound;
using gamedevGame.SreenSelections;

namespace gamedevGame.LevelDesign;

public class LevelManager
{
    private Level _currentLevel;
    private readonly Level[] _allLevels = new Level[2];
    private readonly LevelCreator _levelCreator;
    private int _currentLevelIndex;

    public LevelManager(Hero hero, ContentManager content, GraphicsDeviceManager graphics)
    {
        var level1 = new Level1(hero, content);
        var level2 = new Level2(hero, content);
        
        _allLevels[0] = level1;
        _allLevels[1] = level2;
        
        _currentLevel = level1;
        
        _levelCreator = new LevelCreator(_allLevels, content, graphics);
        _levelCreator.CreateBlocks(_currentLevel);
    }

    public void Update(GameTime gameTime)
    {
        _currentLevel.Update(gameTime);
        if (_currentLevel.Done)
        {
            NextLevel();
        }
    }
    
    public void Draw(SpriteBatch batch)
    {
        _levelCreator.Draw(batch);
    }
    
    private void NextLevel()
    {
        //if last level done change gamestate to win
        if (_currentLevelIndex == _allLevels.Length - 1)
        {
            ScreenSelector.GameState = GameState.Win;
            Game1.SoundManager.Play(Sounds.Win);
        }
        else
        {
            _currentLevelIndex++;
            _currentLevel = _allLevels[_currentLevelIndex];
            _levelCreator.Currentgameboard = _currentLevel.GameBoard;
            
            //resets the hero coins and position and changes position to the starting position of the next level
            _currentLevel.Hero.Reset();
            _currentLevel.Hero.Position = _currentLevel.HeroStartPosition;
            _currentLevel.Hero.RespawnPos = _currentLevel.HeroStartPosition;

            _levelCreator.CreateBlocks(_currentLevel);   
        }
    }
    
    public void Reset()
    {
        _currentLevel.Done = false;
        _currentLevelIndex = 0;
        _currentLevel = _allLevels[_currentLevelIndex];
        _currentLevel.PortalSpawned = false;
        _currentLevel.Done = false;
        _levelCreator.Currentgameboard = _currentLevel.GameBoard;
        _currentLevel.Hero.Reset();
        _currentLevel.Hero.Position = _currentLevel.HeroStartPosition;
        _currentLevel.Hero.RespawnPos = _currentLevel.HeroStartPosition;
        _currentLevel.SoundPlayed = false;
            
        _levelCreator.CreateBlocks(_currentLevel);
    }
}