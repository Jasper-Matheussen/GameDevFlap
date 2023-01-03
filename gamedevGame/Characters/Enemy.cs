using gamedevGame.Animation;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class Enemy : Character
{
    public Enemy(Vector2 startposition, Hero tofollow, ContentManager content) : base()
    {
        WidthCharacter = 50;
        HeightCharacter = 43;
        
        var followHeroReader = new FollowHeroReader(tofollow, this);
        InputReader = followHeroReader;
        Position = startposition;
        GravityPull = Vector2.Zero;
        Speed = new Vector2(0.4f,0.4f);
        
        Texture = content.Load<Texture2D>("spritesheet2");
        
        CreateAnimation(WidthCharacter, HeightCharacter, 4);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, WidthCharacter-5, HeightCharacter -5);
    }
    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(),  Color.Red);
    }
    
}