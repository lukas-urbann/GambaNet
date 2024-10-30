using System.Globalization;
using UnityEngine;

namespace GambaNet.Wrapper
{
    public class CreditManager : MonoBehaviour
    {
        public static CreditManager Instance;
        
        private float UserBalance => LoadUserBalance();
        private float _localUserBalance;

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

        private float LoadUserBalance()
        {
            //TODO: Doplnit tělo, musí to načítat přímo z databáze a musí to tím pádem k ní mít konstantní přístup
            return 500;
        }

        private bool UploadUserBalance()
        {
            //TODO: Doplnit tělo, musí to poslat ten float do databáze
            //Pošleme lokální hodnotu do databáze a user balance se s tím zesynchronizuje
            return false;
        }

        public void UpdateBalance(float amount)
        {
            _localUserBalance += amount;

            while (!UploadUserBalance())
            {
                UploadUserBalance();
            }
        }
        
        public string GetUserBalance()
        {
            return _localUserBalance.ToString(CultureInfo.InvariantCulture);
        }
    }
}