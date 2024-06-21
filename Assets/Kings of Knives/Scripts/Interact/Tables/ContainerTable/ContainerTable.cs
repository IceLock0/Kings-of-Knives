using System;
using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Character;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

public class ContainerTable : BaseTable
{
    [SerializeField] private IngredientInfo _storedIngredient;
    
    public override void Interact()
    {
        if (_currentPlayerIngredient != null && _currentPlayerIngredient.IsCanPutOnContainerTable)
            _isCanPutOnTheTable = true;

        base.Interact();

        if (_isWasInteracted == false && IngredientOnTable == null)
        {
            TakeFromContainer();
        }
    }

    private void TakeFromContainer()
    {
        IngredientOnTable = _storedIngredient;

        TriggerEventFromChild();
    }
}
