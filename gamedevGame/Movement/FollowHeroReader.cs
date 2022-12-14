using gamedevGame.interfaces;

namespace gamedevGame.Movement;

public class FollowHeroReader : IIinputReader
{
    private Hero hero;
    private Character tofollow;
    
    public FollowHeroReader(Hero followhero, IMovable movable)
    {
       hero = followhero;
       tofollow = movable as Character;
    }
    public Vector2 ReadInput()
    {
        Vector2 direction = Vector2.Zero;
        if (tofollow.Position.X - hero.Position.X < 150 && tofollow.Position.X - hero.Position.X > -150)
        {
            if (hero.Position.X > tofollow.Position.X)
            {
                direction.X += 1;
            }
            else if (hero.Position.X < tofollow.Position.X)
            {
                direction.X -= 1;
            }
            if (hero.Position.Y > tofollow.Position.Y)
            {
                direction.Y += 1;
            }
            else if (hero.Position.Y < tofollow.Position.Y)
            {
                direction.Y -= 1;
            }
        }
        return direction;
    }

    public bool IsDestinationInput { get; }
}