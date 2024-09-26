using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kings_of_Knives.Scripts.UI.Ingredient
{
    public class IngredientProgressBarUI : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private Image _background;
        
        public void UpdateBar(float time, float maxTime)
        {
            if (time >= maxTime)
            {
                _bar.fillAmount = 0.0f;
                Hide();
                return;
            }
            
            Show();
            _bar.fillAmount = time / maxTime;
        }

        private void Update()
        {
            Debug.Log($"{Camera.main == null}");
            
            if (Camera.main != null)
                transform.LookAt(Camera.main.transform);
                
        }
        
        private void OnEnable()
        {
            Hide();
        }

        private void Show()
        {
            _bar.enabled = true;
            _background.enabled = true;
        }

        private void Hide()
        {
            _bar.enabled = false;
            _background.enabled = false;
        }
    }
}