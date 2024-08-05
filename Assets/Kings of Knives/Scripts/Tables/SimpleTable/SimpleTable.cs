using UnityEngine;

namespace Kings_of_Knives.Scripts.Tables
{
    public class SimpleTable : BaseTable
    {
        public override void Interact()
        {
            if (CurrentPlayerIngredient != null)
                IsCanPutOnTheTable = CurrentPlayerIngredient.IngredientInfo.IsCanPutOnSimpleTable;
            
            base.Interact();
        }
    }
}