using System;
using gamedevGame.interfaces;
using gamedevGame.Animation;
using Microsoft.Xna.Framework;
using gamedevGame.Movement;
using static System.Formats.Asn1.AsnWriter;
using gamedevGame.LevelDesign;


namespace gamedevGame
{
    enum direction
    {
        Right,
        Left
    }
    public class Hero : IGameObject, IMovable
    {
        Texture2D heroTexture;
        Texture2D hitBoxTexture;
        Animatie animatie;
        Animatie animatieLeft;
        private MovementManager movementManager;

        public Rectangle hitboxHero;

        private direction facing;

        //The heros Width and Height on the spriteSheet
        private int widthHero = 50;
        private int heightHero = 43;

        public int hitboxWidth;
        public int hitboxHeight;

        public int health = 4;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IIinputReader InputReader { get; set; }
        public Vector2 toekomstigePos { get; set; }
        public Block testBlock { get; set; }
        public Rectangle hitbox { get; set; }
        public Vector2 gravityPull { get; set; }

        public Hero(Texture2D texture, Texture2D hitBoxTexture, IIinputReader inputReader, Block testblock)
        {
            //hitbox is voorlopig even groot als de sprite
            hitboxWidth = widthHero;
            hitboxHeight = heightHero;

            heroTexture = texture;
            this.hitBoxTexture = hitBoxTexture;
            InputReader = inputReader;
            animatie = new Animatie();
            animatieLeft = new Animatie();
            Position = new Vector2(50, 150);
            gravityPull = new Vector2(0, 0);

            this.testBlock = testblock;
            hitbox = hitboxHero;
            
            Speed = new Vector2(2, 2);
            movementManager = new MovementManager();

            //Looping 4 times to add 4 frames
            int nextFrame = 0;
            for (int frames = 0; frames < 4; frames++)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, widthHero, heightHero)));
                nextFrame += widthHero;
            }
            //Creating frames for going left animation
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(nextFrame);
                animatieLeft.AddFrame(new AnimationFrame(new Rectangle(nextFrame, 0, widthHero, heightHero)));
                nextFrame += widthHero;
            }
           
        }

        public void Update(GameTime gameTime)
        {       
            Move();
            animatie.Update(gameTime);
            animatieLeft.Update(gameTime);
            hitboxHero = new Rectangle((int)Position.X, (int)Position.Y, widthHero, heightHero);
            hitbox = hitboxHero;
            GetDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Dit nog veranderen if statement verhuizen naar method currentAnimation die de current frame zal return afhankelijk van de direction
            if (facing == direction.Left)
            {
                spriteBatch.Draw(heroTexture, Position, animatieLeft.CurrentFrame.SourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(heroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);
            }
            

            spriteBatch.Draw(hitBoxTexture, hitboxHero, Color.Transparent);
        }

        private void Move()
        { 
            movementManager.Move(this);
        }

        private void GetDirection()
        {
            if (InputReader.ReadInput().X == -1)
            {
                facing = direction.Left;
                ChangeGravity();
            }
            else if(InputReader.ReadInput().X == 1)
            {
                facing = direction.Right;
                ChangeGravity();
            }
        }

        private void ChangeGravity()
        {
            Vector2 newGravity = this.gravityPull;
            switch (facing)
            {
                case direction.Left:
                    newGravity.X = -1;
                    break;
                case direction.Right:
                    newGravity.X = 1;
                    break;
                default:
                    break;
            }
            this.gravityPull = newGravity;
        }

    }
}

