using System;
using gamedevGame.Collision;
using gamedevGame.CollisionEvents;
using gamedevGame.interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevGame.LevelDesign
{
	public class Block : ICollisonable
	{
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Texture2D Texture { get; set; }
        public CollideWithEvent CollideWithEvent { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsPortal { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Tile;

        public Block(int x, int y, Texture2D tilesetTexture)
        {
            BoundingBox = new Rectangle(x, y, 50, 50);
            Passable = false;
            Texture = tilesetTexture;
            Tile = new Rectangle(60, 5, 50, 50);
            CollideWithEvent = new FlyCollision(this);
        }

        public Block(int x, int y, Texture2D tilesetTexture, bool platform) //platform block
        {
            BoundingBox = new Rectangle(x, y, 125, 35);
            Passable = false;
            Texture = tilesetTexture;
            Tile = new Rectangle(239, 5, 125, 35);
            CollideWithEvent = new FlyCollision(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Tile, Color.White);


        }
        public virtual void IsCollidedWithEvent(Hero collider)
        {
            CollideWithEvent.Execute(collider);
        }
    }
}

