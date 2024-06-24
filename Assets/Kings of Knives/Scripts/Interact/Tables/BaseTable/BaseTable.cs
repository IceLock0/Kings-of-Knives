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
        
        protected bool _isWasBaseInteracted;
        protected bool _isCanPutOnTheTable;

        private void OnEnable()
        {
            var playerInventory = PlayerInventory.GetInstance();

            playerInventory.PlayerInventoryChanged += SetPlayerIngredient;
        }

        private void OnDisable()
        {
            var playerInventory = PlayerInventory.GetInstance();

            playerInventory.PlayerInventoryChanged -= SetPlayerIngredient;
        }

        private void Start()
        {
            _playerInventory = PlayerInventory.GetInstance();
        }

        private void SetPlayerIngredient()
        {
            _currentPlayerIngredient = _playerInventory.GetIngredient();
        }

        public virtual void Interact()
        {
            _isWasBaseInteracted = false;

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

            _isWasBaseInteracted = true;
            
            OnIngredientChanged?.Invoke();
        }

        private void ToTable()
        {
            IngredientOnTable = _currentPlayerIngredient;
               
            _playerInventory.SetIngredient(null);
            
            _isWasBaseInteracted = true;

            OnIngredientChanged?.Invoke();
        }

        protected void TriggerEventFromChild()
        {
            OnIngredientChanged?.Invoke();
        }
    }
}