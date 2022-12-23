using gamedevGame.interfaces;

namespace gamedevGame.Movement;

public class PointToPoint : IIinputReader
{
    private IMovable _movable;
    private Vector2 _pointA;
    private Vector2 _pointB;
    private bool _hitPointB;
    private bool _hitPointA = true;

    public PointToPoint(IMovable movable, Vector2 pointA, Vector2 pointB)
    {
        _movable = movable;
        _pointA = pointA;
        _pointB = pointB;
    }
    public Vector2 ReadInput()
    {
        Vector2 direction = Vector2.Zero;
        if (_movable.Position.X >= _pointB.X && !_hitPointB)
        {
            _hitPointB = true;
            _hitPointA = false;
        }
        if (_movable.Position.X <= _pointA.X && !_hitPointA)
        {
            _hitPointA = true;
            _hitPointB = false;
        }
        
        if (_hitPointB)
        {
            direction.X -= 1;
        }
        else if (_hitPointA)
        {
            direction.X += 1;
        }
        return direction;
    }

    public bool IsDestinationInput { get; }
}