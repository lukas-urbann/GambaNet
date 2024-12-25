using System.Globalization;
using UnityEngine;

namespace GambaNet.Wrapper
{
    public class CreditManager : MonoBehaviour
    {
        public static CreditManager Instance;
        
        private double UserBalance => LoadUserBalance();
        private double _localUserBalance;
        private int userId = 1;

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
            string balance = WebWrapper.PostGetUserBalance(WebWrapper.RequestReturnType.UserBalanceDownload, userId: this.userId);
            return double.Parse(balance, CultureInfo.InvariantCulture);
        }

        private void UploadUserBalance()
        {
            string balance = _localUserBalance.ToString("F30", CultureInfo.InvariantCulture).Replace(",", ".");
            Debug.Log(balance);
            Debug.Log(WebWrapper.PostGetUserBalance(WebWrapper.RequestReturnType.UserBalanceUpload, userId: this.userId, newValue: balance));
        }

        public void UpdateBalance(float amount)
        {
            _localUserBalance += amount;
            UploadUserBalance();
        }
        
        public string GetUserBalance()
        {
            return _localUserBalance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}