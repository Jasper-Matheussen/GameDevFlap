using gamedevGame.interfaces;
using gamedevGame.Sound;

namespace gamedevGame.Input;

public class KeyBoardReader : IIinputReader
{
    private bool _spaceBarPressed;
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
        if (state.IsKeyDown(Keys.Space))
        {
            if (!_spaceBarPressed)
            {
                Game1.SoundManager.Play(Sounds.Flap);
                _spaceBarPressed = true;
            }

            direction.Y -= 6;
        }
        else
        {
            _spaceBarPressed = false;
        }


        return direction;

    }
}