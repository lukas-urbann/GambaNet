using UnityEngine;

namespace GambaNet.Generic
{
    public class AudioCall : MonoBehaviour
    {
        public void PlaySound(AudioClip clip)
        {
            AudioPlayer.Instance.PlaySound(clip);
        }
    }
}
