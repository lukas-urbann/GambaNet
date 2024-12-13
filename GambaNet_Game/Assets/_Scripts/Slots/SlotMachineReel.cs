using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Slots
{
    public class SlotMachineReel : MonoBehaviour
    {
        public UnityEvent OnReelSwitch;
        public UnityEvent OnReelFinish = new();
        public static SlotMachineReel Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void SwitchReel()
        {
            OnReelSwitch?.Invoke();
        }

        public void ReelFinish()
        {
            OnReelFinish?.Invoke();
        }
    }
}
