using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kings_of_Knives.Scripts.UI
{
    public class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private Image _background;
        
        public void UpdateBar(float currentTime, float maxTime)
        {
            if (maxTime <= 0.0f)
            {
                HideBar();
                return;
            }

            _bar.fillAmount = currentTime / maxTime;

            if (_bar.fillAmount <= 0.0f || _bar.fillAmount >= 1.0f)
                HideBar();
            else ShowBar();
            
        }
        
        private void ShowBar()
        {
            _background.enabled = true;

            _bar.enabled = true;
        }

        private void HideBar()
        {
            _background.enabled = false;

            _bar.enabled = false;
        }
    }
}