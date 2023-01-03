using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;

namespace gamedevGame.interfaces;

public interface ILevel
{
    public Vector2 HeroStartPosition { get; set; }
    public int[,] GameBoard { get; init; }
    public int[,] Backgroundboard { get; set; }
    public List<Block> Blocks { get; set; }
    public bool Done { get; set; }
    public Hero Hero { get; }
    protected List<Character> EnemyList { get; }
    
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
}