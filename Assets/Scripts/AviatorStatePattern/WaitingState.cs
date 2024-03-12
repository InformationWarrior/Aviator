using UnityEngine;

namespace Aviator
{
    public class WaitingState : BaseGameState, IReset
    {
        private float startValue = 0f;
        private readonly float endValue = 5f;

        public override void EnterState(GameStateManager gameState)
        {
            gameState.ToggleWaitingStateObjects(true);
        }

        public override void UpdateState(GameStateManager gameState)
        {
            if (startValue < endValue)
            {
                startValue += Time.deltaTime;
                gameState.SetSlider(gameState.roundResetSlider, startValue, endValue);
            }

            else if (startValue >= endValue)
            {
                gameState.ToggleWaitingStateObjects(false);
                ResetState();
                gameState.SwitchState(gameState.RunningState);
            }
        }

        public void ResetState()
        {
            startValue = 0;
        }
    }
}