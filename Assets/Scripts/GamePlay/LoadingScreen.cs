using UnityEngine;
using UnityEngine.UI;

namespace Aviator
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject loadingScreen;

        private float startValue = 0f;
        private readonly float endValue = 5f;

        private void Start()
        {
            Init();
        }
        
        private void Update()
        {
            if (startValue < endValue)
            {
                startValue += Time.deltaTime;
                SetSlider(startValue);
            }

            if (startValue >= endValue)
            {
                DisableLoadingScreen();
            }
        }

        private void Init()
        {
            loadingScreen.SetActive(true);
            slider.maxValue = endValue;
        }

        private void SetSlider(float value)
        {
            slider.value = value;
        }

        private void DisableLoadingScreen()
        {
            loadingScreen.SetActive(false);
            slider.gameObject.SetActive(false);
        }
    }
}