using System;
using System.Diagnostics;
using gamedevGame.interfaces;

namespace gamedevGame.Movement
{
	public class MovementManager
	{
        private int _counter;
        public void Move(IMovable movable)
        {

            var gravityPull = movable.GravityPull;
            var direction = movable.InputReader.ReadInput();

            //check and stop how long space bar can be pressed
            if (direction.Y <= -5)
            {
                _counter++;
                
                if (_counter > 6)
                {
                    direction.Y = 0;
                }
                if (_counter > 1000)
                {
                    _counter = 0;
                }
            }
            else
            {
                _counter = 0;
            }
         
            var afstand = direction * movable.Speed;        
            movable.Position += afstand + gravityPull;
        }
    }
}

