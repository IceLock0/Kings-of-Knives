using System;
using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Interact.Tables.CuttingTable;
using Kings_of_Knives.Scripts.Tables;
using Kings_of_Knives.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

public class TableProgressBarUI : ProgressBarUI
{
    [SerializeField] private BaseTable _table;
    
    private IHoldingInteractable _interactable;

    private void Awake()
    {
        UpdateBar(0,0);
        
        if (_table is IHoldingInteractable interactable)
            _interactable = interactable;
    }

    private void OnEnable()
    {
        _interactable.OnHoldTimeChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _interactable.OnHoldTimeChanged -= UpdateBar;
    }
    
}
