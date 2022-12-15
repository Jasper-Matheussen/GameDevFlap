using gamedevGame.Animation;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class Enemy : Character
{
    private Hero _heroToFollow;
    //testing
    private readonly int _widthHero = 50;
    private readonly int _heightHero = 43;
    
    MovementManager _movementManager;
    public Enemy(Vector2 startposition, Hero tofollow, ContentManager content) : base(content)
    {
        var followHeroReader = new FollowHeroReader(tofollow, this);
        InputReader = followHeroReader;
        var movementManager = new MovementManager();
        _movementManager = movementManager;
        Health = 5;
        Position = startposition;
        GravityPull = Vector2.Zero;
        Speed = new Vector2(0.5f,0.5f);
        _heroToFollow = tofollow;
        
        //testing
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
        move();
        Animatie.Update(gameTime);
        AnimatieLeft.Update(gameTime);
    }

    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(), Color.Red);
    }

    private Rectangle CurrentDirectionAnimation() //TODO: dit ook in parent class zetten
    {
        //go left if input.readinput().X is positive
        if (InputReader.ReadInput().X < 0)
        {
            return AnimatieLeft.CurrentFrame.SourceRectangle;
        }
        return Animatie.CurrentFrame.SourceRectangle;
    }

    private void move()
    {
        _movementManager.Move(this);
    }
    
}