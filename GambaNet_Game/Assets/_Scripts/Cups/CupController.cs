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
            winningCup = GenerateRandomCupNumber();
            crunches[winningCup].SetActive(true);
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
            winningCup = GenerateRandomCupNumber();
            cupHolderAnimator.SetTrigger("mix");
            CreditManager.Instance.UpdateBalance(-betAmount);
            betButtonList.buttonsExceptSelected.ForEach(btn => btn.interactable = false);
        }

        public void ChooseCup(int cupNumber)
        {
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
            CreditManager.Instance.UpdateBalance(betAmount * 3);
            OnWinEvent?.Invoke();
        }

        private void OnLose()
        {
            
        }

        private int GenerateRandomCupNumber()
        {
            return Random.Range(0, 3);
        }
    }
}
