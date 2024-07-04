using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    public interface ITable : IInteractable
    {
        public event Action OnIngredientChanged;

        public IIngredient IngredientOnTable { get; set; }
        
    }
}