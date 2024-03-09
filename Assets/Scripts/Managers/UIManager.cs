using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Aviator
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI credits, totalWin;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject invisibleBtn;
        [SerializeField] private GameObject rulesPanel;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            menuPanel.SetActive(false);
            rulesPanel.SetActive(false);
            invisibleBtn.SetActive(false);
        }

        private void SetInvisibleBtn(bool status)
        {
            invisibleBtn.SetActive(status);
        }

        public void OpenRulesPanel()
        {
            rulesPanel.SetActive(true);
            menuPanel.SetActive(false);
            SetInvisibleBtn(true);
        }

        public void CloseRulesPanel()
        {
            rulesPanel.SetActive(false);
            SetInvisibleBtn(false);
        }

        public void OpenMenuPanel()
        {
            menuPanel.SetActive(true);
            SetInvisibleBtn(true);
        }

        public void CloseMenuPanel()
        {
            menuPanel.SetActive(false);
            SetInvisibleBtn(false);
        }

        public void DisplayCredits(float value)
        {
            credits.text = value.ToString("0.00");
        }

        public void DisplayTotalWin(float value)
        {
            totalWin.text = value.ToString("0.00");
        }
    }
}