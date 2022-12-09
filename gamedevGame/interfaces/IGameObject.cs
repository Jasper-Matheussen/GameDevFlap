using System;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevGame.interfaces
{
    public interface IGameObject
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch sprite);
    }
}

