using gamedevGame.interfaces;

namespace gamedevGame.Screens.Buttons;

public abstract class Button : IButton
{
    private Rectangle BoundingBox { get; }
    protected Rectangle Position { get; }
    private Texture2D Texture { get; }
    protected Color Color { get; set; }

    protected Button(Rectangle boundingBox, Rectangle position, ContentManager content, Color color)
    {
        BoundingBox = boundingBox;
        Position = position;
        Texture = content.Load<Texture2D>("Menu");
        Color = color;
    }
    
    public void Update()
    {
        HandleButtonClick();
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, BoundingBox, Color);
    }

    public virtual void HandleButtonClick()
    {
    }
}