using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aviator
{
    public class FinishState : BaseGameState, IReset
    {
        private float startValue = 0f;
        private readonly float endValue = 5f;

        public override void EnterState(GameStateManager gameState)
        {
            gameState.DisplayFlyAwayMultiplier(0.4f);
        }

        public override void UpdateState(GameStateManager gameState)
        {
            if (startValue < endValue)
            {
                startValue += Time.deltaTime;
            }
            else if (startValue >= endValue)
            {
                ResetState();
                gameState.ToggleFlyAwayMultiplierText(false);
                gameState.SwitchState(gameState.WaitingState);
            }
        }

        public void ResetState()
        {
            startValue = 0;
        }
    }
}