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
            _table.OnIngredientChanged += ChangeIngredient;
        }

        private void OnDisable()
        {
            _table.OnIngredientChanged -= ChangeIngredient;
        }

        private void Awake()
        {
            _table = GetComponent<ITable>();
        }

        private void Start()
        {
            ChangeIngredient();
        }

        private void ChangeIngredient()
        {
            if (_table.IngredientOnTable == null)
                ClearTable();

            if (_table.IngredientOnTable != null && _table.IngredientOnTable.Prefab != _lastIngredientPrefab)
                SpawnIngredient();
        }

        private void ClearTable()
        {
            Destroy(_lastIngredientPrefab);
            _lastIngredientPrefab = null;
        }

        private void SpawnIngredient()
        {
            _lastIngredientPrefab = Instantiate(_table.IngredientOnTable.Prefab, _tableTopPointTransform.position,
                Quaternion.identity);
        }
    }
}