using UnityEngine;

namespace GambaNet.Generic
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance;
        public AudioSource source;
        public AudioSource musicSource;

        public bool musicEnabled = true;
        public bool sfxEnabled = true;

        public void ToggleMusic()
        {
            musicEnabled = !musicEnabled;
            UpdatePlayerVolume();
        }

        public void ToggleSFX()
        {
            sfxEnabled = !sfxEnabled;
            UpdatePlayerVolume();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        
        public void PlaySound(AudioClip clip)
        {
            if (!sfxEnabled) return;

            source.PlayOneShot(clip);
        }

        public void UpdatePlayerVolume()
        {
            if (musicEnabled)
            {
                musicSource.volume = 1;
            }
            else
            {
                musicSource.volume = 0;
            }

            if (sfxEnabled)
            {
                source.volume = 1;
            }
            else
            {
                source.volume = 0;
            }
        }
    }
}
