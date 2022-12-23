using gamedevGame.Animation;
using gamedevGame.Movement;

namespace gamedevGame.Characters;

public class ShittingBird : Character
{
    private readonly int _widthHero = 53;
    private readonly int _heightHero = 40;

    public ShittingBird(ContentManager content) : base(content)
    {
        Texture = content.Load<Texture2D>("enemybirdsprite");
        Position = new Vector2(50 ,50);
        GravityPull = Vector2.Zero;
        Speed = new Vector2(1,0.0f);
        
        InputReader = new PointToPoint(this, new Vector2(45,50), new Vector2(1050, 50));

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
    }
    
    public override void Draw(SpriteBatch sprite)
    {
        sprite.Draw(Texture, Position, CurrentDirectionAnimation(),  Color.White);
    }

}