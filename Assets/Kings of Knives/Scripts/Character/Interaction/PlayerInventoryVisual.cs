using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Character.Interaction
{
    public class PlayerInventoryVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _ingredientPrefab;
        [SerializeField] private Transform _playerForwardPointTransform;
        
        private PlayerInventory _playerInventory;

        private GameObject _lastIngredientObject;
        
        private void OnEnable()
        {
            _playerInventory.PlayerInventoryChanged += ChangeIngredient;
        }

        private void OnDisable()
        {
            _playerInventory.PlayerInventoryChanged -= ChangeIngredient;
        }

        private void Awake()
        {
            _playerInventory = PlayerInventory.GetInstance();
        }

        private void Start()
        {
            ChangeIngredient();
        }

        private void ChangeIngredient()
        {
            if (_playerInventory.GetIngredient() == null)
                ClearIngredient();

            if (_playerInventory.GetIngredient() != null &&
                _playerInventory.GetIngredient().Prefab != _ingredientPrefab)
            {
                SpawnIngredient();
            }
        }

        private void ClearIngredient()
        {
            _ingredientPrefab = null;
            Destroy(_lastIngredientObject);
        }

        private void SpawnIngredient()
        {
            _ingredientPrefab = _playerInventory.GetIngredient().Prefab;
            _lastIngredientObject = Instantiate(_ingredientPrefab, _playerForwardPointTransform.position, Quaternion.identity);
            _lastIngredientObject.transform.parent = transform;
        }
    }
}