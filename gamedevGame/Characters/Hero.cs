using gamedevGame.interfaces;

namespace gamedevGame.Characters;

internal enum Direction
{
    Right,
    Left
}
public class Hero : Character
{
    private Direction _facing;
    public bool IsCollidingWithBlock { get; set; }
    public int Coins { get; set; }
    public bool IsDead { get; set; }
    public Vector2 RespawnPos;
    private bool _isBlinking;
    private int _blinkTimer;
    private const int BlinkInterval = 120;
    private int _blinkDuration;
    private Color _originalColor = Color.White;
    private bool _isVisible = true;
    private Color _color = Color.White;
    private Color _blinkColor;

    public Hero(IIinputReader inputReader, ContentManager content) : base()
    {
        WidthCharacter = 50;
        HeightCharacter = 43;
            
        Health = 4;
            
        Texture = content.Load<Texture2D>("spritesheet2");
            
        InputReader = inputReader;

            Position = new Vector2(320 - WidthCharacter, 140);
            GravityPull = new Vector2(0, 0);

            Speed = new Vector2(4, 2);

            CreateAnimation(WidthCharacter, HeightCharacter, 4);
        }

    public override void Update(GameTime gameTime)
    {
        IsCollidingWithBlock = false; 
        base.Update(gameTime);
        CheckIfDead();
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, WidthCharacter - 5, HeightCharacter - 5);
        GetDirection();
        UpdateBlinking(gameTime);
    }

    //Credit for UpdateBlinking Method goes to: ChatGPT AI
    private void UpdateBlinking(GameTime gameTime)
    {
        if (!_isBlinking) return;
        _blinkTimer += gameTime.ElapsedGameTime.Milliseconds;
        if (_blinkTimer >= BlinkInterval)
        {
            _blinkTimer = 0;
            _isVisible = !_isVisible;
            if (!_isVisible)
            {
                _color = _blinkColor;
            }
            else
            {
                _color = _originalColor;
            }
        }

        _blinkDuration--;
        if (_blinkDuration <= 0)
        {
            StopBlinking();
        }
    }

    public void StartBlinking(int duration, Color color)
    {
        _isBlinking = true;
        _blinkTimer = 0;
        _isVisible = true;
        _originalColor = _color;
        _blinkDuration = (duration * 1000 / BlinkInterval);
        _blinkColor = color;
    }

    private void StopBlinking()
    { 
        _isBlinking = false;
        _blinkTimer = 0;
        _isVisible = true;
        _blinkDuration = 0;
        _color = _originalColor;
    }


    public override void Draw(SpriteBatch spriteBatch)
    {
        //Check which direction the hero is facing and draw the appropriate animation
        spriteBatch.Draw(Texture, Position,
            _facing == Direction.Left
                ? AnimatieLeft.CurrentFrame.SourceRectangle
                : Animatie.CurrentFrame.SourceRectangle, _color);
    }
        
    private void GetDirection()
    {
        if (InputReader.ReadInput().X == -1)
        {
            _facing = Direction.Left;
            ChangeGravity();
        }
        else if(InputReader.ReadInput().X == 1)
        {
            _facing = Direction.Right;
            ChangeGravity();
        }
    }

    private void ChangeGravity()
    {
        Vector2 newGravity = GravityPull;
        if (Speed != Vector2.Zero)
        {
            switch (_facing)
            {
                case Direction.Left:
                    newGravity.X = -1;
                    break;
                case Direction.Right:
                    newGravity.X = 1;
                    break;
            }
            GravityPull = newGravity;
        }
           
    }
        
    public void Reset()
    {
        Position = new Vector2(320 - WidthCharacter, 140);
        Coins = 0;
    }

    public void GameOver()
    {
        Reset();
        Health = 4;
    }
        
    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            IsDead = true;
        }
    }
        
    public void Respawn()
    {
        Position = RespawnPos;
    }
}