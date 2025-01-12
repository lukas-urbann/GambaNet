using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Wrapper
{
    public class CreditManager : MonoBehaviour
    {
        public static CreditManager Instance;
        
        private double UserBalance => LoadUserBalance();
        private double _localUserBalance;

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

        private void Start()
        {
            LoadUserBalance();
        }

        private IEnumerator GetBalance()
        {
            val = 0;
            yield return new WaitUntil(() => WebWrapper.Instance.HasConnected.Item1 && WebWrapper.Instance.HasConnected.Item2);

            UnityEvent<string> balanceRespone = new UnityEvent<string>();

            balanceRespone.AddListener((balance) =>
            {
                val = double.Parse(balance, CultureInfo.InvariantCulture);
                _localUserBalance = val;
                WebWrapper.Instance.UserLoaded = true;
            });

            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.UserBalanceDownload, userId: WebWrapper.Instance.GetUserId(), callback: balanceRespone);
        }

        double val = default;
        private double LoadUserBalance()
        {
            StartCoroutine(GetBalance());
            return this.val;
        }

        private void UploadUserBalance()
        {
            //if (!WebWrapper.Instance.HasConnection) return;
            string balance = _localUserBalance.ToString("F30", CultureInfo.InvariantCulture).Replace(",", ".");
            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.UserBalanceUpload, userId: WebWrapper.Instance.GetUserId(), newValue: balance);
        }

        public void UpdateBalance(float amount)
        {
            _localUserBalance += amount;
            UploadUserBalance();
        }

        public bool HasEnoughBalance(float amount)
        {
            return _localUserBalance >= amount;
        }

        public string GetUserBalance()
        {
            return _localUserBalance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}