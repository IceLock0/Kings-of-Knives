using System;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Character.Interaction
{
    public class PlayerInventoryVisual : MonoBehaviour
    {
        [SerializeField] private Transform _holdingPoint;
        
        [Inject] private PlayerInventory _playerInventory;

        private GameObject _lastIngredientObject;

        private void OnEnable()
        {
            _playerInventory.IngredientChanged += ChangeIngredient;
        }

        private void OnDisable()
        {
            _playerInventory.IngredientChanged -= ChangeIngredient;
        }

        private void Start()
        {
            ChangeIngredient(null);
        }

        private void ChangeIngredient(IIngredient ingredient)
        {
            if (ingredient == null)
                DestroyIngredient();

            else InstantiateIngredient(ingredient.IngredientInfo.Prefab);
        }

        private void InstantiateIngredient(GameObject ingredientPrefab)
        {
            _lastIngredientObject = Instantiate(ingredientPrefab, _holdingPoint.position, Quaternion.identity);
            _lastIngredientObject.transform.parent = transform;
        }

        private void DestroyIngredient()
        {
            Destroy(_lastIngredientObject);
        }
    }
}