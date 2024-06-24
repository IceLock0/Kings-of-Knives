using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

public class CuttingTable : BaseTable, IHoldingInteractable
{
    public override void Interact()
    {
        if (_currentPlayerIngredient != null && _currentPlayerIngredient.IsCanPutOnCuttingTable)
            _isCanPutOnTheTable = true;
        
        base.Interact();   
        
        if (_isWasBaseInteracted == false && IngredientOnTable != null)
        {
            Child();
        }
    }

    private void Child()
    {
        TriggerEventFromChild();
    }

    public void HoldingInteract()
    {
        throw new System.NotImplementedException();
    }
}
