using System;
using TMPro;
using UnityEngine;

namespace Aviator
{
    public class BetPanel : MonoBehaviour
    {
        [SerializeField] private int PanelIndex;

        [SerializeField] private TextMeshProUGUI currentBetText, playBtnCurrentBetText;
        [SerializeField] private GameObject manualModeSelect, autoModeSelect;
        [SerializeField] private GameObject autoPlayBtn, autoPlayPanel;
        [SerializeField] private RectTransform betSelectorPosition, playBtnPosition;

        public int CurrentBet { get; private set; }


        private Vector2 defaultBetSelectorPosition;
        private Vector2 newBetSelectorPosition;
        private Vector2 defaultPlayBtnPosition;
        private Vector2 newPlayBtnPosition;

        private readonly int[] bets = new int[] { 10, 15, 20, 25, 30, 35, 40, 45, 50, 75, 100, 125, 150, 200 };
        private int currentBetIndex = 0;

        private void Awake()
        {
            defaultBetSelectorPosition = betSelectorPosition.anchoredPosition;
            defaultPlayBtnPosition = playBtnPosition.anchoredPosition;

            newBetSelectorPosition = new Vector2(defaultBetSelectorPosition.x, -15);
            newPlayBtnPosition = new Vector2(defaultPlayBtnPosition.x, -15);
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            ManualMode();
            DisplayCurrentBet(currentBetIndex);
        }

        public void ManualMode()
        {
            manualModeSelect.SetActive(true);
            autoModeSelect.SetActive(false);
            autoPlayBtn.SetActive(false);
            autoPlayPanel.SetActive(false);
            SetBetSelectorAndPlayBtnPosition(defaultBetSelectorPosition, defaultPlayBtnPosition);
        }

        public void AutoMode()
        {
            manualModeSelect.SetActive(false);
            autoModeSelect.SetActive(true);
            autoPlayBtn.SetActive(true);
            autoPlayPanel.SetActive(true);
            SetBetSelectorAndPlayBtnPosition(newBetSelectorPosition, newPlayBtnPosition);
        }

        public void IncreaseBet()
        {
            currentBetIndex++;

            if (currentBetIndex >= bets.Length)
            {
                currentBetIndex = 0;
            }

            DisplayCurrentBet(currentBetIndex);
        }

        public void DecreaseBet()
        {
            currentBetIndex--;

            if (currentBetIndex < 0)
            {
                currentBetIndex = bets.Length - 1;
            }

            DisplayCurrentBet(currentBetIndex);
        }

        public void SelectBet(int bet)
        {
            currentBetIndex = Array.IndexOf(bets, bet);
            DisplayCurrentBet(currentBetIndex);
        }

        private void SetBetSelectorAndPlayBtnPosition(Vector2 betSelectorPosition, Vector2 playBtnPosition)
        {
            this.betSelectorPosition.anchoredPosition = betSelectorPosition;
            this.playBtnPosition.anchoredPosition = playBtnPosition;
        }

        private void DisplayCurrentBet(int index)
        {
            CurrentBet = bets[index];
            currentBetText.text = CurrentBet.ToString();
            playBtnCurrentBetText.text = CurrentBet.ToString();
        }
    }
}