using System;
using Kings_of_Knives.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingTable _cuttingTable;
    
    [SerializeField] private Image _image;
    [SerializeField] private Image _background;
    
    
    private void OnEnable()
    {
        _cuttingTable.OnHoldTimeChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _cuttingTable.OnHoldTimeChanged -= UpdateBar;
    }

    private void Start()
    {
        _image.fillAmount = 0.0f;
        
        HideBar();
    }

    private void UpdateBar(float currentCuttingTime, float maxCuttingTime)
    {
        _image.fillAmount = currentCuttingTime / maxCuttingTime;
        
        if (currentCuttingTime <= 0.0f && currentCuttingTime >= 1.0f)
        {
            HideBar();
        }
        else ShowBar();
        
    }

    private void HideBar()
    {
        _image.enabled = false;

        _background.enabled = false;
    }

    private void ShowBar()
    {
        _image.enabled = true;

        _background.enabled = true;
    }
}
