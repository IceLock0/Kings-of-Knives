using System;
using Kings_of_Knives.Scripts.Character;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kings_of_Knives.Scripts.Tables
{
    public class BaseTable : MonoBehaviour, ITable
    {
        public bool CanInteract { get; set; }

        public event Action OnIngredientChanged;
        public IngredientInfo IngredientOnTable { get; set; }

        private PlayerInventory _playerInventory;

        protected IngredientInfo _currentPlayerIngredient;
        
        protected bool _isWasInteracted;
        protected bool _isCanPutOnTheTable;

        private void Start()
        {
            _playerInventory = PlayerInventory.GetInstance();
        }

        public virtual void Interact()
        {
            _isWasInteracted = false;

            _currentPlayerIngredient = _playerInventory.GetIngredient();
            
            if (_currentPlayerIngredient != null)
            {
                if (IngredientOnTable == null && _isCanPutOnTheTable)
                    ToTable();
            }

            else if (_currentPlayerIngredient == null)
            {
                if(IngredientOnTable != null && IngredientOnTable.IsCanTake == true)
                    ToInventory();
            }
        }
        
        private void ToInventory()
        {
            _playerInventory.SetIngredient(IngredientOnTable);

            IngredientOnTable = null;

            _isWasInteracted = true;
            
            OnIngredientChanged?.Invoke();
        }

        private void ToTable()
        {
            IngredientOnTable = _currentPlayerIngredient;
               
            _playerInventory.SetIngredient(null);
            
            _isWasInteracted = true;

            OnIngredientChanged?.Invoke();
        }

        protected void TriggerEventFromChild()
        {
            OnIngredientChanged?.Invoke();
        }
    }
}