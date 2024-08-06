using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.View.Inventory
{
    public class PlayerInventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _holdingPoint;

        [Inject] private PlayerInventory _playerInventory;

        private void ChangeIngredientPosition()
        {
            if (_playerInventory.Ingredient == null)
                return;

            _playerInventory.Ingredient.transform.position = _holdingPoint.position;
            _playerInventory.Ingredient.transform.parent = _holdingPoint;
        }
        
        private void OnEnable()
        {
            _playerInventory.IngredientChanged += ChangeIngredientPosition;
        }
        
        private void OnDisable()
        {
            _playerInventory.IngredientChanged -= ChangeIngredientPosition;
        }
    }
}