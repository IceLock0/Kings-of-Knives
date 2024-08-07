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

            var playerTransform = _playerInventory.Ingredient.transform;
            
            playerTransform.position = _holdingPoint.position;
            playerTransform.parent = transform;
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