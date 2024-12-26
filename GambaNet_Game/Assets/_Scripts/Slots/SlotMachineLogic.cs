using System;
using System.Collections.Generic;
using GambaNet.Wrapper;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;


//nejhorsi skript co jsem kdy napsal, ale dela co ma :((
namespace GambaNet.Slots
{
    public class SlotMachineLogic : MonoBehaviour
    {
        public static SlotMachineLogic Instance;
        
        [SerializeField] private List<BonusType> possibleBonusTypes = new(); // List of possible bonuses
        private SlotBonus[,] slotBonuses = new SlotBonus[5, 5]; // 2D array of SlotBonus objects
        public GameObject gridParent;
        //private int lostRoundInRow = 0;
        //private int winRoundInRow = 0;
        //public int maxLosses = 16;
        public List<GameObject> rowLights = new();
        private float betAmount;
        public UnityEvent OnWin;
        [SerializeField] private int winratePercentage = 100;

        public void SetWinningChange(int percentage)
        {
            winratePercentage = percentage;
        }

        public void SetBetAmount(float amount) => betAmount = amount;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            SlotMachineReel.Instance.OnReelSwitch.AddListener(OnReel);
            StarterAssignBonusesToSlots();
        }

        private void StarterAssignBonusesToSlots()
        {
            int childIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    slotBonuses[i, j] = gridParent.transform.GetChild(childIndex).GetComponent<SlotBonus>();
                    slotBonuses[i, j].SetBonusType(ChooseRandomBonusType());
                    childIndex++;
                }
            }
        }

        private void OnReel()
        {
            CreditManager.Instance.UpdateBalance(-betAmount);
            StarterAssignBonusesToSlots();
            if (!GetWinChance()) return;

            OnWin?.Invoke();
            float winCount = (int)ChooseWinningCount();
            BonusType bonus = ChooseRandomBonusType();
            
            GenerateWinningRow(ChooseWinningRow(), (int)winCount, bonus);
            
            CreditManager.Instance.UpdateBalance(winCount * betAmount * bonus.bonusMultiplier);
        }

        private void GenerateWinningRow(int row, int count, BonusType bonus)
        {
            for(int i = 0; i < 5; i++)
            {
                if (count >= 5)
                {
                    OverwriteBonusToSlot(row - 1, i, bonus);
                    continue;
                }
                else
                {
                    if (i < count)
                    {
                        OverwriteBonusToSlot(row - 1, i, bonus);
                    }
                    else
                    {
                        BonusType newBonus = ChooseRandomBonusType();
                        while(newBonus == bonus)
                        {
                            newBonus = ChooseRandomBonusType();
                        }

                        OverwriteBonusToSlot(row - 1, i, newBonus);
                    }

                }
            }

            EnableRowLight(row);
        }

        public void DisableRowLights() => rowLights.ForEach(o => o.SetActive(false));

        private void EnableRowLight(int row)
        {
            rowLights[row-2].SetActive(true);
        }

        private void OverwriteBonusToSlot(int x, int y, BonusType bonus) => slotBonuses[x, y].GetComponent<SlotBonus>().SetBonusType(bonus);

        private BonusType ChooseRandomBonusType()
        {
            var random = new Random();
            var randomIndex = random.Next(0, possibleBonusTypes.Count);
            return possibleBonusTypes[randomIndex];
        }

        private float ChooseWinningCount()
        {
            var count = (float)Math.Floor(3 + UnityEngine.Random.Range(0 + (0.2f * UnityEngine.Random.Range(0,4)), 3) - UnityEngine.Random.Range(0,2));
            return count < 3 ? 3 : count;
        }

        //2-4
        private int ChooseWinningRow()
        {
            return UnityEngine.Random.Range(2, 5);
        }

        private bool GetWinChance()
        {
            var random = new Random();
            var randomValue = random.Next(0, 100);
            return randomValue < winratePercentage;
        }

        /*
        private bool GetWinChance()
        {
            if (winRoundInRow > 1)
            {
                winRoundInRow = 0;
                lostRoundInRow++;
                return false;
            }

            if (lostRoundInRow > maxLosses)
            {
                lostRoundInRow = 0;
                winRoundInRow++;
                return true;
            }

            if (UnityEngine.Random.Range(0, maxLosses - lostRoundInRow) == 0)
            {
                winRoundInRow++;
                lostRoundInRow = 0;
                return true;
            }

            winRoundInRow = 0;
            lostRoundInRow++;
            return false;
        }
        */
    }
}
