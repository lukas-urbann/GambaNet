using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Generic
{
    public class AudioCall : MonoBehaviour
    {
        public UnityEvent<bool> musicEnabled = new();
        public UnityEvent<bool> sfxEnabled = new();

        public void PlaySound(AudioClip clip) => AudioPlayer.Instance.PlaySound(clip);
        public void ToggleMusic()
        {
            AudioPlayer.Instance.ToggleMusic();
            musicEnabled?.Invoke(!AudioPlayer.Instance.musicEnabled);
        }

        public void ToggleSFX()
        {
            AudioPlayer.Instance.ToggleSFX();
            sfxEnabled?.Invoke(!AudioPlayer.Instance.sfxEnabled);
        }
    }
}
