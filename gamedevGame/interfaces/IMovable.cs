using System;
using gamedevGame.LevelDesign;
namespace gamedevGame.interfaces
{
	public interface IMovable
	{
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 GravityPull { get; set; }
        public IIinputReader InputReader { get; set; }
        public Rectangle Hitbox { get; set; }

    }
}

