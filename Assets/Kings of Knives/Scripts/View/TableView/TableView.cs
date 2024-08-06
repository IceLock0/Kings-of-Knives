using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.View
{
    public class TableView : MonoBehaviour
    {
        [SerializeField] private Transform _holdingPoint;
        
        private ITable _table;

        private void Awake()
        {
            _table = GetComponent<ITable>();

            if (_table == null)
                throw new NullReferenceException("ITable component not founded");
        }

        private void ChangeIngredientPosition()
        {
            if (_table.Ingredient == null)
                return;
            
            _table.Ingredient.transform.position = _holdingPoint.position;
            _table.Ingredient.transform.parent = _holdingPoint;
        }
        
        private void OnEnable()
        {
            _table.IngredientChanged += ChangeIngredientPosition;
        }
        
        private void OnDisable()
        {
            _table.IngredientChanged -= ChangeIngredientPosition;
        }
        
    }
}