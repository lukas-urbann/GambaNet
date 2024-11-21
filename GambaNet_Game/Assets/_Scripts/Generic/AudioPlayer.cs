using UnityEngine;

namespace GambaNet.Generic
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance;
        public AudioSource source;
        
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
            source.PlayOneShot(clip);
        }
    }
}
