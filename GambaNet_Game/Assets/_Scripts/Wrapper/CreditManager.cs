using System.Globalization;
using UnityEngine;

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
            _localUserBalance = UserBalance;
        }

        private double LoadUserBalance()
        {
            if (!WebWrapper.HasConnection)
            {
                return 0;
            }

            string balance = WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.UserBalanceDownload, userId: WebWrapper.LoadUserId());
            return double.Parse(balance, CultureInfo.InvariantCulture);
        }

        private void UploadUserBalance()
        {
            if (!WebWrapper.HasConnection)
            {
                return;
            }

            string balance = _localUserBalance.ToString("F30", CultureInfo.InvariantCulture).Replace(",", ".");
            WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.UserBalanceUpload, userId: WebWrapper.LoadUserId(), newValue: balance);
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