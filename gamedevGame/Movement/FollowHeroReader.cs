using gamedevGame.Characters;
using gamedevGame.interfaces;

namespace gamedevGame.Movement;

public class FollowHeroReader : IIinputReader
{
    private Hero hero;
    private Character follower;

    public FollowHeroReader(Hero followhero, IMovable movable)
    {
       hero = followhero;
       follower = movable as Character;
    }
    public Vector2 ReadInput()
    {
        

        if (follower.Hitbox.Intersects(hero.Hitbox))
        {
            return Vector2.Zero;
        }
        else
        {
            return Vector2.Normalize(hero.Position - follower.Position);
        }

        Vector2 direction = Vector2.Zero;
        if (follower.Position.X - hero.Position.X < 300 && follower.Position.X - hero.Position.X > -300)
        {
            if (hero.Position.X > follower.Position.X)
            {
                direction.X += 1;
            }
            else if (hero.Position.X < follower.Position.X)
            {
                direction.X -= 1;
            }
            if (hero.Position.Y > follower.Position.Y)
            {
                direction.Y += 1;
            }
            else if (hero.Position.Y < follower.Position.Y)
            {
                direction.Y -= 1;
            }
        }
        return direction;
    }

    public bool IsDestinationInput { get; }
}