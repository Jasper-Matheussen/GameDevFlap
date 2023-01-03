namespace gamedevGame.Screens.Buttons;

public class ExitButton : Button
{
    public ExitButton(Rectangle boundingBox, Rectangle position, ContentManager content, Color color) : base(boundingBox, position, content, color)
    {
    }

    public override void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (Position.Contains(mouseState.Position))
            {
                Environment.Exit(0);
            }
        }
    }
    
}