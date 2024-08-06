using UnityEngine;

namespace Kings_of_Knives.Scripts.Services.Fabric.Ingredient
{
    public interface IIngredientFabric
    {
        public void Load();
        public Scripts.Ingredient CreateIngredientFromSO(IngredientInfo ingredientInfo, Vector3 at, Transform parent = null);
    }
}