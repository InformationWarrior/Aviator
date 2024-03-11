using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aviator
{
    public static class MultiplierGenerator
    {
        private const float minValue = 0.0f;
        private const float maxValue = 5.0f;

        public static float Multiplier { get; private set; } = GenerateMultiplier();

        private static float GenerateMultiplier()
        {
            float randomMultiplier = Random.Range(minValue, maxValue);
            return randomMultiplier;
        }
    }
}