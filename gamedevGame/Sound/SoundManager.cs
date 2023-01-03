namespace gamedevGame.Sound;

public enum Sounds
{
    Flap,
    Hurt,
    Collect,
    Heart,
    Next,
    GameOver,
    Win
}
public class SoundManager
{
    private readonly List<SoundEffect> _soundEffects;
    private readonly Song _song;

    public SoundManager()
    {            
        _soundEffects = new List<SoundEffect>
        {
            Game1.content.Load<SoundEffect>("flap"),
            Game1.content.Load<SoundEffect>("hurt"),
            Game1.content.Load<SoundEffect>("collect"),
            Game1.content.Load<SoundEffect>("heart"),
            Game1.content.Load<SoundEffect>("next"),
            Game1.content.Load<SoundEffect>("gamover"),
            Game1.content.Load<SoundEffect>("win")
        };
        _song = Game1.content.Load<Song>("themesong");
    }

    public void Play(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.Flap:
                _soundEffects[0].Play();
                break;
            case Sounds.Hurt:
                _soundEffects[1].Play();
                break;
            case Sounds.Collect:
                _soundEffects[2].Play();
                break;
            case Sounds.Heart:
                _soundEffects[3].Play();
                break;
            case Sounds.Next:
                _soundEffects[4].Play();
                break;
            case Sounds.GameOver:
                _soundEffects[5].Play();
                break;
            case Sounds.Win:
                _soundEffects[6].Play();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sound), sound, null);
        }

    }

    public void PlayThemeSong()
    {
        MediaPlayer.Play(_song);
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.1f;
    }
}