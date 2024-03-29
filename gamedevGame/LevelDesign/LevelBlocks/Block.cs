﻿using gamedevGame.Characters;
using gamedevGame.Collision.CollisionEvents;
using gamedevGame.interfaces;

namespace gamedevGame.LevelDesign.LevelBlocks;

public enum BlockType
{
    Platform,
    GreyBlock,
    BlueBlock,
}
public class Block : ICollisonable
	{
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        protected Texture2D Texture { get; init; }
        protected CollideWithEvent CollideWithEvent { get; init; }
        public bool IsVisible { get; protected init; } = true;
        public bool IsPortal { get; protected init; }
        public int X { get; protected init; }
        public int Y { get; protected init; }
        protected Rectangle Tile;

        public Block(int x, int y, Texture2D tilesetTexture)
        {
            BoundingBox = new Rectangle(x, y, 50, 50);
            Passable = false;
            Texture = tilesetTexture;
            Tile = new Rectangle(60, 5, 50, 50);
            CollideWithEvent = new FlyCollision(this);
        }

        public Block(int x, int y, Texture2D tilesetTexture, BlockType type) //platform block
        {
            switch (type)
            {
                case BlockType.Platform:
                    BoundingBox = new Rectangle(x, y, 125, 35);
                    Passable = false;
                    Tile = new Rectangle(239, 5, 125, 35);
                    CollideWithEvent = new FlyCollision(this);
                    break;
                case BlockType.BlueBlock:
                    BoundingBox = new Rectangle(x, y, 50, 50);
                    Passable = false;
                    Tile = new Rectangle(182, 5, 50, 50);
                    CollideWithEvent = new FlyCollision(this);
                    break;
            }
            Texture = tilesetTexture;
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

