using UnityEngine;

namespace Kings_of_Knives.Scripts.Tables
{
    public class SimpleTable : BaseTable
    {
        public override void Interact()
        {
            if (_currentPlayerIngredient != null)
                _isCanPutOnTheTable = _currentPlayerIngredient.IngredientInfo.IsCanPutOnSimpleTable;
            
            base.Interact();
        }
    }
}