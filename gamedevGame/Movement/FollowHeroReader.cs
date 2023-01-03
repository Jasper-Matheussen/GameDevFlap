using gamedevGame.Characters;
using gamedevGame.interfaces;

namespace gamedevGame.Movement;

public class FollowHeroReader : IIinputReader
{
    private readonly Hero _hero;
    private readonly Character _follower;

    public FollowHeroReader(Hero followhero, IMovable movable)
    {
       _hero = followhero;
       _follower = movable as Character;
    }
    public Vector2 ReadInput()
    {
        return _follower.Hitbox.Intersects(_hero.Hitbox) ? Vector2.Zero : Vector2.Normalize(_hero.Position - _follower.Position);
    }
}