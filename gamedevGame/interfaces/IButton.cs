namespace gamedevGame.interfaces;

public interface IButton
{
    void Update();
    void Draw(SpriteBatch spriteBatch);
    protected void HandleButtonClick();
}