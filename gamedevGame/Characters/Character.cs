using gamedevGame.Animation;
using gamedevGame.interfaces;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class Character : IGameObject, IMovable
{
    protected Texture2D Texture;
    protected readonly Animatie Animatie;
    protected readonly Animatie AnimatieLeft;
    
    protected int WidthCharacter;
    protected int HeightCharacter;
    
    public Vector2 Position { get; set; }
    public Vector2 Speed { get; set; }
    public Vector2 GravityPull { get; set; }
    public IIinputReader InputReader { get; set; }
    public Rectangle Hitbox { get; set; }

    public int Health;
    private readonly MovementManager _movementManager;

    protected Character()
    {
        _movementManager = new MovementManager();
        Animatie = new Animatie();
        AnimatieLeft = new Animatie();
    }
    

    public virtual void Update(GameTime gameTime)
    {
        Move();
        Animatie.Update(gameTime);
        AnimatieLeft.Update(gameTime);
    }

    public virtual void Draw(SpriteBatch sprite)
    {
    }
    
    protected Rectangle CurrentDirectionAnimation()
    {
        //go left if input.readinput().X is positive
        return InputReader.ReadInput().X < 0 ? AnimatieLeft.CurrentFrame.SourceRectangle : Animatie.CurrentFrame.SourceRectangle;
    }

    private void Move()
    {
        _movementManager.Move(this);
    }

    protected void CreateAnimation(int widthHero, int heightHero, int totalFrames)
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