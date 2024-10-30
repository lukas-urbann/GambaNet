using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace GambaNet.Slots
{
    public class SlotMachineLogic : MonoBehaviour
    {
        public static SlotMachineLogic Instance;
        
        [SerializeField] private List<BonusType> possibleBonusTypes = new(); // List of possible bonuses
        public bool shouldWin = false; // Indicates if the player should win or not, calculated by other scripts
        private SlotBonus[,] slotBonuses = new SlotBonus[5, 5]; // 2D array of SlotBonus objects
        public GameObject gridParent;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void OnEnable()
        {
            SlotMachineReel.Instance.OnReelSwitch.AddListener(AssignBonusesToSlots);
            AssignBonusesToSlots();
        }

        private void AssignBonusesToSlots()
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GenerateBonusGrid();
            }
        }

        public void GenerateBonusGrid()
        {
            bool shouldWin = GetWinChance();

            
        }

        public BonusType ChooseRandomBonusType()
        {
            var random = new Random();
            var randomIndex = random.Next(0, possibleBonusTypes.Count);
            return possibleBonusTypes[randomIndex];
        }

        public int ChooseWinningRow()
        {
            return UnityEngine.Random.Range(0, 5);
        }

        public bool GetWinChance()
        {
            return shouldWin;
        }
    }
}
