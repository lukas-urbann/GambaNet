using GambaNet.Buttons;
using GambaNet.Wrapper;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Cups
{
    public class CupController : MonoBehaviour
    {
        public List<GameObject> crunches = new();
        public List<Button> cups = new();
        public Animator cupHolderAnimator;
        private float betAmount;
        private int winningCup;
        public UnityEvent OnEndEvent = new();
        public UnityEvent OnWinEvent = new();
        public MultiButtonSelector betButtonList;

        [SerializeField] private int winratePercentage = 100;

        public void SetBetAmount(float amount) => betAmount = amount;

        private void OnEnable()
        {
            PlaceRandomCrunch();
        }

        public void HideCrunches()
        {
            crunches.ForEach(crunch => crunch.SetActive(false));
        }

        public void GameReady()
        {
            //winningCup = GenerateRandomCupNumber();
            //crunches[winningCup].SetActive(true);
            //negeneruje se to tady, až po kliknutí na kelímek kvùli winratu
            cups.ForEach(cup => cup.interactable = true);
        }

        public void EndGame()
        {
            cups.ForEach(cup => cup.interactable = false);
            cupHolderAnimator.SetTrigger("show");
            OnEndEvent?.Invoke();
            betButtonList.buttonsExceptSelected.ForEach(btn => btn.interactable = true);
        }

        private void PlaceRandomCrunch()
        {
            int randomIndex = Random.Range(0, crunches.Count);
            crunches[randomIndex].SetActive(true);
        }

        public void StartGame()
        {
            cups.ForEach(cup => cup.interactable = false);
            cupHolderAnimator.SetTrigger("mix");
            CreditManager.Instance.UpdateBalance(-betAmount);
            betButtonList.buttonsExceptSelected.ForEach(btn => btn.interactable = false);
        }

        public void ChooseCup(int cupNumber)
        {
            GenerateWinningCupNumber(cupNumber);
            crunches[winningCup].SetActive(true);

            if (cupNumber == winningCup)
            {
                OnWin();
            }
            else
            {
                OnLose();
            }

            EndGame();
        }

        private void OnWin()
        {
            CreditManager.Instance.UpdateBalance(betAmount * 2);
            OnWinEvent?.Invoke();
        }

        private void OnLose()
        {
            
        }

        public void SetWinningChange(int percentage)
        {
            winratePercentage = percentage;
        }

        private int GenerateWinningCupNumber(int selectedCup)
        {
            int random = Random.Range(0, 100);

            if (random < winratePercentage)
            {
                return winningCup = selectedCup;
            }
            else
            {
                while (winningCup == selectedCup)
                {
                    winningCup = Random.Range(0, cups.Count);
                }

                return winningCup;
            }
        }
    }
}
