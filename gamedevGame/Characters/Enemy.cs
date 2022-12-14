using gamedevGame.Animation;

namespace gamedevGame;

public class Enemy : Character
{
    private Hero _heroToFollow;
    //testing
    private readonly int _widthHero = 50;
    private readonly int _heightHero = 43;
    public Enemy(Vector2 startposition, Hero tofollow, ContentManager content) : base(content)
    {
        Health = 5;
        Position = startposition;
        GravityPull = Vector2.Zero;
        Speed = Vector2.Zero;
        _heroToFollow = tofollow;
        
        //testing
        Texture = content.Load<Texture2D>("spritesheet2");
        
        int nextFrame = 0;
        for (int frames = 0; frames < 4; frames++)
        {
            Animatie.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
            nextFrame += _widthHero;
        }
        //Creating frames for going left animation
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(nextFrame);
            AnimatieLeft.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
            nextFrame += _widthHero;
        }
    }
    
    public override void Update(GameTime gameTime)
    { 
        Animatie.Update(gameTime);
        AnimatieLeft.Update(gameTime);
    }

    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, AnimatieLeft.CurrentFrame.SourceRectangle, Color.Red);
    }
}