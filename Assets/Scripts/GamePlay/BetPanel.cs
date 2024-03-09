using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator
{
    public class BetPanel : MonoBehaviour
    {
        [SerializeField] private int PanelIndex;

        [SerializeField] private TextMeshProUGUI currentBetText, playBtnCurrentBetText;
        [SerializeField] private TMP_InputField cashOutInputField;
        [SerializeField] private GameObject manualModeSelect, autoModeSelect;
        [SerializeField] private GameObject autoPlayBtn, autoPlayPanel;
        [SerializeField] private GameObject autoCashOutSliderOn, autoCashOutSliderOff;
        [SerializeField] private RectTransform betSelectorPosition, playBtnPosition;
        [SerializeField] private Image autoPlayImage;
        [SerializeField] private Sprite autoPlayEnabled, autoPlayDisabled;
        public int CurrentBet { get; private set; } = 10;
        public float CashOut { get; private set; } = 1.10f;

        private bool autoCashOutSliderStatus = false;
        private bool autoPlayImageStatus = false;

        private Vector2 defaultBetSelectorPosition;
        private Vector2 newBetSelectorPosition;
        private Vector2 defaultPlayBtnPosition;
        private Vector2 newPlayBtnPosition;

        private readonly float yPos = 15f;
        private readonly int[] bets = new int[] { 10, 15, 20, 25, 30, 35, 40, 45, 50, 75, 100, 125, 150, 200 };

        private int currentBetIndex = 0;

        private void Awake()
        {
            defaultBetSelectorPosition = betSelectorPosition.anchoredPosition;
            defaultPlayBtnPosition = playBtnPosition.anchoredPosition;

            newBetSelectorPosition = new Vector2(defaultBetSelectorPosition.x, -yPos);
            newPlayBtnPosition = new Vector2(defaultPlayBtnPosition.x, -yPos);
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            autoCashOutSliderStatus = false;
            autoPlayImageStatus = false;
            cashOutInputField.interactable = false;
            ManualMode();
            UpdateBet(bets[currentBetIndex]);
            DisplayCashOutValue(CashOut);
        }

        public void ToggleAutoPlay()
        {
            if (autoPlayImageStatus)
            {
                autoPlayImageStatus = false;
                SetAutoPlayImage(autoPlayDisabled);
            }
            else
            {
                autoPlayImageStatus = true;
                SetAutoPlayImage(autoPlayEnabled);
            }
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

            UpdateBet(bets[currentBetIndex]);
        }

        public void DecreaseBet()
        {
            currentBetIndex--;

            if (currentBetIndex < 0)
            {
                currentBetIndex = bets.Length - 1;
            }

            UpdateBet(bets[currentBetIndex]);
        }

        public void SelectBet(int bet)
        {
            currentBetIndex = Array.IndexOf(bets, bet);
            UpdateBet(bets[currentBetIndex]);
        }

        public void AutoCashOutSlider()
        {
            if (autoCashOutSliderStatus)
            {
                SetCashOutSlider(false);
            }
            else
            {
                SetCashOutSlider(true);
            }
        }

        public void CashOutInput()
        {
            bool status = float.TryParse(cashOutInputField.text, out float inputValue);

            if (status)
            {
                if (inputValue <= 1.01f)
                    inputValue = 1.01f;
                else if (inputValue >= 100)
                    inputValue = 100f;
            }
            else
            {
                inputValue = 1.10f;
            }

            CashOut = inputValue;
            DisplayCashOutValue(CashOut);
        }

        private void SetAutoPlayImage(Sprite sprite)
        {
            if (sprite != null && autoPlayImage != null)
            {
                autoPlayImage.sprite = sprite;
            }
        }

        private void SetCashOutSlider(bool status)
        {
            autoCashOutSliderStatus = status;
            autoCashOutSliderOn.SetActive(status);
            autoCashOutSliderOff.SetActive(!status);
            cashOutInputField.interactable = status;
            DisplayCashOutValue(CashOut);
        }

        private void SetBetSelectorAndPlayBtnPosition(Vector2 betSelectorPosition, Vector2 playBtnPosition)
        {
            this.betSelectorPosition.anchoredPosition = betSelectorPosition;
            this.playBtnPosition.anchoredPosition = playBtnPosition;
        }

        private void UpdateBet(int bet)
        {
            CurrentBet = bet;
            DisplayCurrentBet(CurrentBet);
        }

        private void DisplayCurrentBet(int bet)
        {
            currentBetText.text = bet.ToString();
            playBtnCurrentBetText.text = bet.ToString();
        }

        private void DisplayCashOutValue(float value)
        {
            cashOutInputField.text = value.ToString("0.00");
        }
    }
}