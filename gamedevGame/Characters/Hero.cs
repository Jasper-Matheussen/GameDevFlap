﻿using gamedevGame.Animation;
using gamedevGame.interfaces;
using gamedevGame.Movement;

namespace gamedevGame.Characters
{
    internal enum Direction
    {
        Right,
        Left
    }
    public class Hero : Character
    {
        private Direction _facing;
        
        public int Coins { get; set; }
        public bool IsDead { get; set; }
        public Vector2 RespawnPos;

        public Hero(IIinputReader inputReader, ContentManager content) : base(content)
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
            base.Update(gameTime);
            CheckIfDead();
            Animatie.Update(gameTime);
            AnimatieLeft.Update(gameTime);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, WidthCharacter-5, HeightCharacter -5);
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
}

