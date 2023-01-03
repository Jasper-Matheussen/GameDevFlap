namespace gamedevGame.Animation;

public class AnimationFrame
{
    public Rectangle SourceRectangle { get; }

    public AnimationFrame(Rectangle rectangle)
    {
        SourceRectangle = rectangle;
    }
}