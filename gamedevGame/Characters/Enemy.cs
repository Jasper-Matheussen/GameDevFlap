using gamedevGame.Animation;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class Enemy : Character
{
    private readonly int _widthHero = 50;
    private readonly int _heightHero = 43;
    
    public Enemy(Vector2 startposition, Hero tofollow, ContentManager content) : base(content)
    {
        var followHeroReader = new FollowHeroReader(tofollow, this);
        InputReader = followHeroReader;
        Health = 5;
        Position = startposition;
        GravityPull = Vector2.Zero;
        Speed = new Vector2(0.4f,0.4f);
        
        Texture = content.Load<Texture2D>("spritesheet2");
        
        //TODO: dit nog aanpassen 2x zelfde code
        int nextFrame = 0;
        for (int frames = 0; frames < 4; frames++)
        {
            Animatie.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
            nextFrame += _widthHero;
        }
        //Creating frames for going left animation
        for (int i = 0; i < 4; i++)
        {
            AnimatieLeft.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
            nextFrame += _widthHero;
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Animatie.Update(gameTime);
        AnimatieLeft.Update(gameTime);
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, _widthHero-5, _heightHero -5);
    }
    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(),  Color.Red);
    }
    
}