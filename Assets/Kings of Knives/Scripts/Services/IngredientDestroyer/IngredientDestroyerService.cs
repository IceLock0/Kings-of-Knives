using Unity.VisualScripting;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Services.IngredientDestroyer
{
    public class IngredientDestroyerService : MonoBehaviour
    {
        public void DestroyIngredient(Ingredient ingredient)
        {
            Destroy(ingredient.GameObject());
        }
    }
}