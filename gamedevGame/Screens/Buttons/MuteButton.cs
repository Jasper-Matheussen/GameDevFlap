namespace gamedevGame.Screens.Buttons;

public class MuteButton : Button
{
    private Color _colorMuteButton = Color.Green;
    private bool _muteClicked;
    public MuteButton(Rectangle boundingBox, Rectangle position, ContentManager content, Color color) : base(boundingBox, position, content, color)
    {
    }
    
    protected override void HandleButtonClick()
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (Position.Contains(mouseState.Position))
            {
                if (_colorMuteButton == Color.Green && !_muteClicked)
                {
                    _colorMuteButton = Color.Red;
                    MediaPlayer.Pause();
                    _muteClicked = true;
                }
                else if (!_muteClicked)
                {
                    MediaPlayer.Resume();
                    _colorMuteButton = Color.Green;
                    _muteClicked = true;
                }
            }
        }
        else
        {
            _muteClicked = false;
        }
        Color = _colorMuteButton;
    }
}