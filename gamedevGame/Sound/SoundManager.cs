using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevGame.Sound
{
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
        private List<SoundEffect> soundEffects = new List<SoundEffect>();

        public SoundManager()
        {            
            soundEffects.Add(Game1.content.Load<SoundEffect>("flap"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("hurt"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("collect"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("heart"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("next"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("gamover"));
            soundEffects.Add(Game1.content.Load<SoundEffect>("win"));
        }

        public void Play(Sounds sound)
        {
            switch (sound)
            {
                case (Sounds.Flap):
                    soundEffects[0].Play();
                    break;
                case Sounds.Hurt:
                    soundEffects[1].Play();
                    break;
                case Sounds.Collect:
                    soundEffects[2].Play();
                    break;
                case Sounds.Heart:
                    soundEffects[3].Play();
                    break;
                case Sounds.Next:
                    soundEffects[4].Play();
                    break;
                case Sounds.GameOver:
                    soundEffects[5].Play();
                    break;
                case Sounds.Win:
                    soundEffects[6].Play();
                    break;
            }

        }
    }
}
