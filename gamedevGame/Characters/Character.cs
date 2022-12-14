using gamedevGame.interfaces;

namespace gamedevGame;

public class Character : IGameObject, IMovable
{
    public Vector2 Position { get; set; }
    public Vector2 Speed { get; set; }
    public Vector2 GravityPull { get; set; }
    public IIinputReader InputReader { get; set; }
    public Rectangle Hitbox { get; set; }
    
    
    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Draw(SpriteBatch sprite)
    {
    }
    
}