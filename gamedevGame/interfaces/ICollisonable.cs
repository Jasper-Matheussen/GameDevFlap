using System;
namespace gamedevGame.interfaces
{
	public interface ICollisonable
	{
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        void Draw(SpriteBatch sprite);

    }
}

