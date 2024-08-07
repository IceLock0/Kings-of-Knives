using Kings_of_Knives.Scripts.Services.Fabric.Ingredient;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Interact.Tables.ContainerTable
{
    public class ContainerTable : BaseTable
    {
        [SerializeField] private IngredientInfo _storedIngredientInfo;

        [Inject] private IIngredientFabric _ingredientFabric;
        
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
            Ingredient = _ingredientFabric.CreateIngredientFromSO(_storedIngredientInfo, Vector3.zero);
            TriggerEventFromChild();
        }
    }
}
