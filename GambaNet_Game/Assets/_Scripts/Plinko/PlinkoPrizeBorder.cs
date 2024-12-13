using GambaNet.Wrapper;
using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Plinko
{
    public class PlinkoPrizeBorder : MonoBehaviour
    {
        [SerializeField] private float betMultiplicator = 1;
        public UnityEvent onPrizeBorderHit = new();

        public float GetMultiplicator()
        {
            return betMultiplicator;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8)
            {
                float value = other.GetComponent<PlinkoBonus>().GetValue();
                Destroy(other.gameObject);
                CreditManager.Instance.UpdateBalance(value * betMultiplicator);
                onPrizeBorderHit?.Invoke();
            }
        }
    }
}