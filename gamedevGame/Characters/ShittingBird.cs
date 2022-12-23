using gamedevGame.Animation;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class ShittingBird : Character
{
    private readonly int _widthHero = 53;
    private readonly int _heightHero = 40;
    private Color color;
    
    public ShittingBird(ContentManager content, Vector2 startPos, Vector2 moveTo, Vector2 speed, Color color) : base(content)
    {
        this.color = color;
        Texture = content.Load<Texture2D>("enemybirdsprite");
        Position = startPos;
        GravityPull = Vector2.Zero;
        Speed = speed;
        
        InputReader = new PointToPoint(this, startPos, moveTo);

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
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(),  color);
    }
    
    public void ShootShit()
    {
        //Implement if (Goesting)
        
    }

}