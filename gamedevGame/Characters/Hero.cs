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
        private readonly Texture2D _heroTexture;
        private readonly Animatie _animatie;
        private readonly Animatie _animatieLeft;
        private readonly MovementManager _movementManager;

        public Rectangle HitboxHero;

        private Direction _facing;

        //The heros Width and Height on the spriteSheet
        private readonly int _widthHero = 50;
        private readonly int _heightHero = 43;
        
        public int Health = 4;

        public Hero(Texture2D texture, IIinputReader inputReader)
        {
            _heroTexture = texture;
            InputReader = inputReader;
            _animatie = new Animatie();
            _animatieLeft = new Animatie();
            Position = new Vector2(50, 150);
            GravityPull = new Vector2(0, 2);
            
            Hitbox = HitboxHero;
            
            Speed = new Vector2(2, 2);
            _movementManager = new MovementManager();

            //Looping 4 times to add 4 frames
            int nextFrame = 0;
            for (int frames = 0; frames < 4; frames++)
            {
                _animatie.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
                nextFrame += _widthHero;
            }
            //Creating frames for going left animation
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(nextFrame);
                _animatieLeft.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, _widthHero, _heightHero)));
                nextFrame += _widthHero;
            }
           
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            _animatie.Update(gameTime);
            _animatieLeft.Update(gameTime);
            HitboxHero = new Rectangle((int)Position.X, (int)Position.Y, _widthHero, _heightHero);
            Hitbox = HitboxHero;
            GetDirection();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Dit nog veranderen if statement verhuizen naar method currentAnimation die de current frame zal return afhankelijk van de direction
            if (_facing == Direction.Left)
            {
                spriteBatch.Draw(_heroTexture, Position, _animatieLeft.CurrentFrame.SourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(_heroTexture, Position, _animatie.CurrentFrame.SourceRectangle, Color.White);
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
}

