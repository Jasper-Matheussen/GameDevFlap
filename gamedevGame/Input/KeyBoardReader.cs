﻿using System;
using gamedevGame.interfaces;
using gamedevGame.Sound;

namespace gamedevGame.Input
{
	public class KeyBoardReader : IIinputReader
	{

        public bool IsDestinationInput => false;
        bool spaceBarPressed = false;
        public Vector2 ReadInput()
        {
            
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                if (!spaceBarPressed)
                {
                    Game1.SoundManager.Play(Sounds.Flap);
                    spaceBarPressed = true;
                }

                direction.Y -= 6;
            }
            else
            {
                spaceBarPressed = false;
            }


            return direction;

        }
    }
}

