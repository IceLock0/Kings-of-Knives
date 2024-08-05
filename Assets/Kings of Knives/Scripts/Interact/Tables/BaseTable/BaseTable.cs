using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Tables
{
    public class BaseTable : MonoBehaviour, ITable
    {
        public bool CanInteract { get; set; }

        public event Action OnIngredientChanged;
        
       [Inject] private PlayerInventory _playerInventory;
        
        public IIngredient IngredientOnTable { get; set; }
        
        protected IIngredient _currentPlayerIngredient;
        
        protected bool _isWasBaseInteracted;
        protected bool _isCanPutOnTheTable = false;

        private void OnEnable()
        {
            _playerInventory.IngredientChanged += GetPlayerIngredient;
        }

        private void OnDisable()
        {
            _playerInventory.IngredientChanged -= GetPlayerIngredient;
        }

        private void GetPlayerIngredient(IIngredient ingredient)
        {
            _currentPlayerIngredient = ingredient;
        }

        public virtual void Interact()
        {
            _isWasBaseInteracted = false;

            if (_currentPlayerIngredient != null)
            {
                if (IngredientOnTable == null && _isCanPutOnTheTable)
                {
                    ToTable();
                }
            }

            else if (_currentPlayerIngredient == null)
            {
                if(IngredientOnTable != null && IngredientOnTable.IngredientInfo.IsCanTake == true)
                    ToInventory();
            }
        }

        private void ToTable()
        {
            IngredientOnTable = _currentPlayerIngredient;
               
            _playerInventory.ChangeIngredient(null);
            
            _isWasBaseInteracted = true;

            OnIngredientChanged?.Invoke();
        }
        
        private void ToInventory()
        {
            _playerInventory.ChangeIngredient(IngredientOnTable);

            IngredientOnTable = null;

            _isWasBaseInteracted = true;
            
            OnIngredientChanged?.Invoke();
        }

        protected void TriggerEventFromChild()
        {
            OnIngredientChanged?.Invoke();
        }
    }
}