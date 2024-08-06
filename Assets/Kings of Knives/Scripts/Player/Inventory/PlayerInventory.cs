using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Character
{
    public class PlayerInventory
    {
        public Ingredient Ingredient { get; private set; }

        public event Action IngredientChanged;

        public void ChangeIngredient(Ingredient ingredient)
        {
            Ingredient = ingredient;

            IngredientChanged?.Invoke();
        }
    }
}