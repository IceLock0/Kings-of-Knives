using System;
using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

public class ContainerTable : BaseTable
{
    [SerializeField] private IngredientInfo _storedIngredient;
    
    public override void Interact()
    {
        if (_currentPlayerIngredient != null)
            _isCanPutOnTheTable = _currentPlayerIngredient.IngredientInfo.IsCanPutOnContainerTable;

        base.Interact();

        if (_isWasBaseInteracted == false && IngredientOnTable == null)
        {
            TakeFromContainer();
        }
    }

    private void TakeFromContainer()
    {
        IngredientOnTable = new Ingredient(_storedIngredient);

        TriggerEventFromChild();
    }
}
