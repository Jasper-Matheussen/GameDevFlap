namespace gamedevGame;

public class Enemy : Character
{
    private Hero _heroToFollow;
    public Enemy(Vector2 startposition, Hero tofollow, ContentManager content) : base(content)
    {
        Health = 5;
        Position = startposition;
        GravityPull = Vector2.Zero;

        _heroToFollow = tofollow;
    }
}