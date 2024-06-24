using UnityEngine;

namespace Kings_of_Knives.Scripts.Tables
{
    public class SimpleTable : BaseTable
    {
        public override void Interact()
        {
            if (_currentPlayerIngredient != null && _currentPlayerIngredient.IsCanPutOnSimpleTable)
            {
                _isCanPutOnTheTable = true;
            }
            
            base.Interact();
        }
    }
}