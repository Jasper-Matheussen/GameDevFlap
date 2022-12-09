using System;
using gamedevGame.interfaces;
using gamedevGame.Animation;
using Microsoft.Xna.Framework;
using gamedevGame.Movement;
using static System.Formats.Asn1.AsnWriter;
using gamedevGame.LevelDesign;


namespace gamedevGame
{
    internal enum Direction
    {
        Right,
        Left
    }
    public class Hero : IGameObject, IMovable
    {
        private readonly Texture2D _heroTexture;
        private readonly Texture2D _hitBoxTexture;
        private readonly Animatie _animatie;
        private readonly Animatie _animatieLeft;
        private readonly MovementManager _movementManager;

        public Rectangle HitboxHero;

        private Direction _facing;

        //The heros Width and Height on the spriteSheet
        private readonly int _widthHero = 50;
        private readonly int _heightHero = 43;

        public int HitboxWidth;
        public int HitboxHeight;

        public int Health = 4;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IIinputReader InputReader { get; set; }
        public Vector2 ToekomstigePos { get; set; }
        public Block TestBlock { get; set; }
        public Rectangle Hitbox { get; set; }
        public Vector2 GravityPull { get; set; }

        public Hero(Texture2D texture, Texture2D hitBoxTexture, IIinputReader inputReader, Block testblock)
        {
            //hitbox is voorlopig even groot als de sprite
            HitboxWidth = _widthHero;
            HitboxHeight = _heightHero;

            _heroTexture = texture;
            this._hitBoxTexture = hitBoxTexture;
            InputReader = inputReader;
            _animatie = new Animatie();
            _animatieLeft = new Animatie();
            Position = new Vector2(50, 150);
            GravityPull = new Vector2(0, 0);

            this.TestBlock = testblock;
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

        public void Update(GameTime gameTime)
        {       
            Move();
            _animatie.Update(gameTime);
            _animatieLeft.Update(gameTime);
            HitboxHero = new Rectangle((int)Position.X, (int)Position.Y, _widthHero, _heightHero);
            Hitbox = HitboxHero;
            GetDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
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
            

            spriteBatch.Draw(_hitBoxTexture, HitboxHero, Color.Transparent);
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

