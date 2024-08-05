using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    public interface ITable : IInteractable
    {
        public event Action IngredientChanged;

        public IIngredient Ingredient { get; }

        public void ChangeIngredient(IIngredient ingredient);

    }
}