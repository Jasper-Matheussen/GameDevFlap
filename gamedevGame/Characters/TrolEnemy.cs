using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class TrolEnemy : Character
{

    private readonly Color _color;
    
    public TrolEnemy(ContentManager content, Vector2 startPos, Vector2 moveTo, Vector2 speed, Color color) : base()
    {
        WidthCharacter = 53;
        HeightCharacter = 40;
        
        _color = color;
        Texture = content.Load<Texture2D>("enemybirdsprite");
        Position = startPos;
        GravityPull = Vector2.Zero;
        Speed = speed;
        
        InputReader = new PointToPoint(this, startPos, moveTo);

        CreateAnimation(WidthCharacter, HeightCharacter, 4);
    }
    
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, WidthCharacter-5, HeightCharacter -5);
    }
    
    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(),  _color);
    }
}