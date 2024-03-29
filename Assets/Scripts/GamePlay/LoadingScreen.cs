using UnityEngine;

namespace Aviator
{
    public class LoadingScreen : BaseGameState
    {
        private float startValue = 0f;
        private readonly float endValue = 5f;

        public override void EnterState(GameStateManager gameState)
        {
            gameState.ToggleLoadingScreenObjects(true);
        }

        public override void UpdateState(GameStateManager gameState)
        {
            if (startValue < endValue)
            {
                startValue += Time.deltaTime;
                gameState.SetSlider(gameState.loadingSlider, startValue, endValue);
            }

            else if (startValue >= endValue)
            {
                gameState.ToggleLoadingScreenObjects(false);
                gameState.SwitchState(gameState.WaitingState);
            }
        }
    }
}