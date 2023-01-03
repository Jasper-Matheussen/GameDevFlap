namespace gamedevGame.Animation;

public class Animatie
{
    public AnimationFrame CurrentFrame { get; set; }

    private readonly List<AnimationFrame> _frames;
    private double _secondCounter;
    private int _counter;

    public Animatie()
    {
        _frames = new List<AnimationFrame>();
    }

    public void AddFrame(AnimationFrame animationFrame)
    {
        _frames.Add(animationFrame);
        CurrentFrame = _frames[0];
    }

    public void Update(GameTime gameTime)
    {
        CurrentFrame = _frames[_counter];

        _secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
        const int fps = 15;

        if (_secondCounter >= 1d / fps)
        {
            _counter++;
            _secondCounter = 0;
        }

        if (_counter >= _frames.Count)
            _counter = 0;
    }
}