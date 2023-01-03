namespace gamedevGame.Screens.Buttons;

public abstract class Button
{
    public Rectangle BoundingBox { get; set; }
    public Rectangle Position { get; set; }
    public Texture2D Texture { get; set; }
    public Color Color { get; set; }

    public Button(Rectangle boundingBox, Rectangle position, ContentManager content, Color color)
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

    protected virtual void HandleButtonClick()
    {
    }
}