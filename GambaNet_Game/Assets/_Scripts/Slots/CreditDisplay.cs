using GambaNet.Wrapper;
using TMPro;
using UnityEngine;

namespace GambaNet.Slots
{
    public class CreditDisplay : MonoBehaviour
    {
        public TMP_Text creditText;

        private void Update()
        {
            creditText.text = CreditManager.Instance.GetUserBalance();
        }
    }
}