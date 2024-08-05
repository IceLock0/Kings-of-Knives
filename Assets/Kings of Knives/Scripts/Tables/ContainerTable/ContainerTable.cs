using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Interact.Tables.ContainerTable
{
    public class ContainerTable : BaseTable
    {
        [SerializeField] private IngredientInfo _storedIngredient;
    
        public override void Interact()
        {
            if (CurrentPlayerIngredient != null)
                IsCanPutOnTheTable = CurrentPlayerIngredient.IngredientInfo.IsCanPutOnContainerTable;

            base.Interact();

            if (IsWasBaseInteracted == false && Ingredient == null)
            {
                TakeFromContainer();
            }
        }

        private void TakeFromContainer()
        {
            Ingredient = new Ingredient(_storedIngredient);

            TriggerEventFromChild();
        }
    }
}
