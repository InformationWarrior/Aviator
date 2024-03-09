using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aviator
{    
    public class CreditsManager : MonoBehaviour
    {
        public float Credits { get; private set; } = 10000;
        public float TotalWin { get; private set; } = 0;

        private void Start()
        {
            DisplayCredits(Credits);
            DisplayTotalWin(TotalWin);
        }

        private void DisplayCredits(float value)
        {
            GameManager.Instance.UIManager.DisplayCredits(value);
        }

        private void DisplayTotalWin(float value)
        {
            GameManager.Instance.UIManager.DisplayTotalWin(value);
        }
    }
}