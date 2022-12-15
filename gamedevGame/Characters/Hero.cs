using gamedevGame.interfaces;
using gamedevGame.Animation;
using gamedevGame.Movement;


namespace gamedevGame
{
    internal enum Direction
    {
        Right,
        Left
    }
    public class Hero : Character
    {
        private readonly MovementManager _movementManager;

        private Rectangle _hitboxHero;
        private Direction _facing;

        //The heros Width and Height on the spriteSheet
        private readonly int _widthHero = 50;
        private readonly int _heightHero = 43;
        
        public int Coins { get; set; }

        public Hero(IIinputReader inputReader, ContentManager content) : base(content)
        {
            Health = 4;
            
            Texture = content.Load<Texture2D>("spritesheet2");
            
            InputReader = inputReader;

            Position = new Vector2(320 - _widthHero, 140);
            GravityPull = new Vector2(0, 0);
            
            Hitbox = _hitboxHero;
            
            Speed = new Vector2(4, 2);
            _movementManager = new MovementManager();
            
            //Looping 4 times to add 4 frames -> dit miss in de character class zetten zodat je het niet voor elke char hoeft te doen
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
            Move();
            Animatie.Update(gameTime);
            AnimatieLeft.Update(gameTime);
            _hitboxHero = new Rectangle((int)Position.X, (int)Position.Y, _widthHero-5, _heightHero -5);
            Hitbox = _hitboxHero;
            GetDirection();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Dit nog veranderen if statement verhuizen naar method currentAnimation die de current frame zal return afhankelijk van de direction
            if (_facing == Direction.Left)
            {
                spriteBatch.Draw(Texture, Position, AnimatieLeft.CurrentFrame.SourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, Animatie.CurrentFrame.SourceRectangle, Color.White);
            }
        }

        private void Move()
        { 
            _movementManager.Move(this);
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
            Vector2 newGravity = this.GravityPull;
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
                    default:
                        break;
                }
                this.GravityPull = newGravity;
            }
           
        }
        
        public void Reset()
        {
            Position = new Vector2(320 - _widthHero, 140);
            Coins = 0;
        }
    }
}

