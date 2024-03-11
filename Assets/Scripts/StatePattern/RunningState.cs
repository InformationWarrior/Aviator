using UnityEngine;

namespace Aviator
{
    public class RunningState : BaseGameState, IReset
    {
        private float startValue = 0f;
        private float multiplierEndValue;

        public override void EnterState(GameStateManager gameState)
        {
            multiplierEndValue = 0.4f;
        }

        public override void UpdateState(GameStateManager gameState)
        {
            if (startValue < multiplierEndValue)
            {
                startValue += 0.1f * Time.deltaTime;
                gameState.DisplayMultiplier(startValue);
            }
            else if (startValue >= multiplierEndValue)
            {
                ResetState();
                gameState.ToggleMultiplierText(false);
                gameState.SwitchState(gameState.FinishState);
            }
        }

        public void ResetState()
        {
            startValue = 0;
        }
    }
}