using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Character
{
    public class PlayerInventory
    {
        public IIngredient Ingredient { get; private set; }

        public event Action<IIngredient> IngredientChanged;

        public void ChangeIngredient(IIngredient ingredient)
        {
            Ingredient = ingredient;

            IngredientChanged?.Invoke(Ingredient);
        }
    }
}