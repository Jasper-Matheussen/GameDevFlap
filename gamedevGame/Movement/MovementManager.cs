using System;
using gamedevGame.interfaces;

namespace gamedevGame.Movement
{
	public class MovementManager
	{
        int counter;
        public void Move(IMovable movable)
        {

            var gravityPull = movable.gravityPull;
            var direction = movable.InputReader.ReadInput();

            //check and stop how long space bar can be pressed
            if (direction.Y <= -5)
            {
                counter++;
                
                if (counter > 6)
                {
                    direction.Y = 0;
                }
                if (counter > 1000)
                {
                    counter = 0;
                }
            }
            else
            {
                counter = 0;
            }
         
            var afstand = direction * movable.Speed;        
            movable.Position += afstand + gravityPull;

        }
    }
}

