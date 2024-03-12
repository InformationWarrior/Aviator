using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator
{
    public class GameStateManager : MonoBehaviour
    {
        private BaseGameState currentGameState = null;

        public LoadingScreen LoadingScreen = new();
        public WaitingState WaitingState = new();
        public RunningState RunningState = new();
        public FinishState FinishState = new();

        public Slider loadingSlider;
        [SerializeField] private GameObject loadingScreen;

        [SerializeField] private GameObject roundResetAnimation;
        public Slider roundResetSlider;
        [SerializeField] private GameObject waitingText;

        [SerializeField] private TextMeshProUGUI multiplierText;

        [SerializeField] private TextMeshProUGUI finishMultiplierText;
        [SerializeField] private GameObject flyAwayText;
        [SerializeField] private GameObject crashText;
        
        private void Start()
        {
            SwitchState(WaitingState);
        }

        private void Update()
        {
            currentGameState.UpdateState(this);
        }

        public void SwitchState(BaseGameState state)
        {
            currentGameState = state;
            currentGameState.EnterState(this);
        }

        public void ToggleLoadingScreenObjects(bool status)
        {
            loadingScreen.SetActive(status);
            loadingSlider.gameObject.SetActive(status);
        }

        public void ToggleWaitingStateObjects(bool status)
        {
            roundResetAnimation.SetActive(status);
            waitingText.SetActive(status);
            roundResetSlider.gameObject.SetActive(status);
        }

        public void SetSlider(Slider slider, float value, float endValue)
        {
            if (slider != null)
            {
                slider.maxValue = endValue;
                slider.value = value;
            }
        }

        public void DisplayMultiplier(float value)
        {
            ToggleMultiplierText(true);
            multiplierText.text = value.ToString("0.00") + "x";
        }

        public void ToggleMultiplierText(bool status)
        {
            multiplierText.gameObject.SetActive(status);
        }

        public void DisplayFlyAwayMultiplier(float value)
        {
            ToggleFlyAwayMultiplierText(true);
            finishMultiplierText.text = value.ToString("0.00") + "x";
        }

        public void ToggleFlyAwayMultiplierText(bool status)
        {
            flyAwayText.SetActive(status);
            finishMultiplierText.gameObject.SetActive(status);
        }

        public void ToggleCrashFlyAwayText(bool status)
        {
            crashText.SetActive(status);
        }
    }
}