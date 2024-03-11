using UnityEngine;

namespace Aviator
{
    public abstract class BaseGameState
    {
        public abstract void EnterState(GameStateManager gameState);
        public abstract void UpdateState(GameStateManager gameState);
    }
}