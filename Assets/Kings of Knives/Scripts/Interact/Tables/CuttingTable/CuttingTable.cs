using System;
using System.Collections.Generic;
using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

public class CuttingTable : BaseTable, IHoldingInteractable
{
    public event Action<float, float> OnHoldTimeChanged;

    public override void Interact()
    {
        if (_currentPlayerIngredient != null)
            _isCanPutOnTheTable = _currentPlayerIngredient.IngredientInfo.IsCanPutOnCuttingTable;

        base.Interact();
    }

    private Dictionary<IIngredient, float> _dictionary = new Dictionary<IIngredient, float>();

    public void HoldingInteract()
    {
        if (IngredientOnTable == null || IngredientOnTable.IngredientInfo.IsCanCut == false)
            return;

        if (IngredientOnTable.IngredientInfo.Output is not IngredientCuttingInfo ingredientCuttingInfo)
            return;

        var cuttingTime = 0.0f;

        if (_dictionary.ContainsKey(IngredientOnTable))
            cuttingTime = _dictionary[IngredientOnTable];
        else _dictionary.Add(IngredientOnTable, cuttingTime);

        var timeToCutting = ingredientCuttingInfo.TimeToCutting;

        cuttingTime += Time.deltaTime;
        
        OnHoldTimeChanged?.Invoke(cuttingTime, timeToCutting);

        if (cuttingTime >= ingredientCuttingInfo.TimeToCutting)
        {
            IngredientOnTable = new Ingredient(IngredientOnTable.IngredientInfo.Output);
            
            TriggerEventFromChild();

            _dictionary.Remove(IngredientOnTable);

            return;
        }

        _dictionary[IngredientOnTable] = cuttingTime;
    }
}