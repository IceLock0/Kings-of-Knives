using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    public class TableVisual : MonoBehaviour
    {
        [SerializeField] private Transform _tableTopPointTransform;

        private ITable _table;

        private GameObject _lastIngredientPrefab;

        private void OnEnable()
        {
            _table.IngredientChanged += ChangeIngredient;
        }

        private void OnDisable()
        {
            _table.IngredientChanged -= ChangeIngredient;
        }

        private void Awake()
        {
            _table = GetComponent<ITable>();
            
            if(_table == null)
                throw new NullReferenceException("ITable component not founded");
        }

        private void Start()
        {
            ChangeIngredient();
        }

        private void ChangeIngredient()
        {
            if (_table.Ingredient == null)
                ClearTable();

            if (_table.Ingredient != null && _table.Ingredient.IngredientInfo.Prefab != _lastIngredientPrefab)
            {
                ClearTable();
                SpawnIngredient();
            }
        }

        private void ClearTable()
        {
            Destroy(_lastIngredientPrefab);
            _lastIngredientPrefab = null;
        }

        private void SpawnIngredient()
        {
            _lastIngredientPrefab = Instantiate(_table.Ingredient.IngredientInfo.Prefab, _tableTopPointTransform.position,
                Quaternion.identity);
            
            _lastIngredientPrefab.transform.parent = transform;
        }
    }
}