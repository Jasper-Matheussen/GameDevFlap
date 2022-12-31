using gamedevGame.Animation;
using gamedevGame.interfaces;
using gamedevGame.Movement;

namespace gamedevGame;

public class Character : IGameObject, IMovable
{
    protected Texture2D Texture;
    protected Animatie Animatie;
    protected Animatie AnimatieLeft;
    
    protected int WidthCharacter;
    protected int HeightCharacter;
    
    public Vector2 Position { get; set; }
    public Vector2 Speed { get; set; }
    public Vector2 GravityPull { get; set; }
    public IIinputReader InputReader { get; set; }
    public Rectangle Hitbox { get; set; }

    public int Health;
    protected MovementManager MovementManager;

    protected Character(ContentManager content)
    {
        MovementManager = new MovementManager();
        Animatie = new Animatie();
        AnimatieLeft = new Animatie();
    }
    

    public virtual void Update(GameTime gameTime)
    {
        Move();
    }

    public virtual void Draw(SpriteBatch sprite)
    {
    }
    
    protected Rectangle CurrentDirectionAnimation()
    {
        //go left if input.readinput().X is positive
        if (InputReader.ReadInput().X < 0)
        {
            return AnimatieLeft.CurrentFrame.SourceRectangle;
        }
        return Animatie.CurrentFrame.SourceRectangle;

    }
    
    public void Move()
    {
        MovementManager.Move(this);
    }

    public void CreateAnimation(int widthHero, int heightHero, int totalFrames)
    {
        int nextFrame = 0;
        for (int frames = 0; frames < totalFrames; frames++)
        {
            Animatie.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, widthHero, heightHero)));
            nextFrame += widthHero;
        }
        //Creating frames for going left animation
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(nextFrame);
            AnimatieLeft.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, widthHero, heightHero)));
            nextFrame += widthHero;
        }
    }
}