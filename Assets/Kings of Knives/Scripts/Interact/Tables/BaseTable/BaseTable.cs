using System;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Tables
{
    public class BaseTable : MonoBehaviour, ITable
    {
        public bool CanInteract { get; set; }

        public event Action OnIngredientChanged;
        
        private PlayerInventory _playerInventory;
        
        public IIngredient IngredientOnTable { get; set; }
        
        protected IIngredient _currentPlayerIngredient;
        
        protected bool _isWasBaseInteracted;
        protected bool _isCanPutOnTheTable = false;

        private void OnEnable()
        {
            var playerInventory = PlayerInventory.GetInstance();

            playerInventory.PlayerInventoryChanged += GetPlayerIngredient;
        }

        private void OnDisable()
        {
            var playerInventory = PlayerInventory.GetInstance();

            playerInventory.PlayerInventoryChanged -= GetPlayerIngredient;
        }

        private void Start()
        {
            _playerInventory = PlayerInventory.GetInstance();
            
        }

        private void GetPlayerIngredient()
        {
            _currentPlayerIngredient = _playerInventory.GetIngredient();
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
               
            _playerInventory.SetIngredient(null);
            
            _isWasBaseInteracted = true;

            OnIngredientChanged?.Invoke();
        }
        
        private void ToInventory()
        {
            _playerInventory.SetIngredient(IngredientOnTable);

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