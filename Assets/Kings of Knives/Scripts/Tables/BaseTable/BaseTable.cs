using System;
using Kings_of_Knives.Scripts.Character;
using Kings_of_Knives.Scripts.Services.Fabric.Ingredient;
using Kings_of_Knives.Scripts.Services.IngredientDestroyer;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Tables
{
    public abstract class BaseTable : MonoBehaviour, ITable
    {
        public event Action IngredientChanged;
        
        public Ingredient Ingredient { get; set; }

        protected Ingredient CurrentPlayerIngredient;
        
        protected bool IsWasBaseInteracted = false;
        protected bool IsCanPutOnTheTable = false;
        
        private PlayerInventory _playerInventory;
        private IngredientDestroyerService _ingredientDestroyerService;
        private IIngredientFabric _ingredientFabric;
        
        [Inject]
       public void Initialize(PlayerInventory playerInventory, IngredientDestroyerService ingredientDestroyerService, IIngredientFabric ingredientFabric)
       {
           _playerInventory = playerInventory;
           _ingredientDestroyerService = ingredientDestroyerService;
           _ingredientFabric = ingredientFabric;
       }
       
       public virtual void Interact()
       {
           IsWasBaseInteracted = false;

           if (CurrentPlayerIngredient != null)
           {
               if (Ingredient == null && IsCanPutOnTheTable)
               {
                   ToTable();
               }
           }

           else if (CurrentPlayerIngredient == null)
           {
               if(Ingredient != null && Ingredient.IngredientInfo.IsCanTake)
                   ToInventory();
           }
       }
       
       public void ChangeIngredient(Ingredient ingredient)
       {
           Ingredient = ingredient;

           IngredientChanged?.Invoke();
           
           IsWasBaseInteracted = true;
       }
       
       protected void TriggerEventFromChild()
       {
           IngredientChanged?.Invoke();
       }

       protected void ReplaceIngredientByCook()
       {
           _ingredientDestroyerService.DestroyIngredient(Ingredient);
            
           Ingredient = _ingredientFabric.CreateIngredientFromSO(Ingredient.IngredientInfo.Output,
               Ingredient.transform.position, Ingredient.transform.parent);

           IngredientChanged?.Invoke();
       }
       
       private void OnEnable()
        {
            _playerInventory.IngredientChanged += GetPlayerIngredient;
        }

        private void OnDisable()
        {
            _playerInventory.IngredientChanged -= GetPlayerIngredient;
        }

        private void GetPlayerIngredient()
        {
            CurrentPlayerIngredient = _playerInventory.Ingredient;
        }
        

        private void ToTable()
        {
            ChangeIngredient(_playerInventory.Ingredient);
               
            _playerInventory.ChangeIngredient(null);
        }
        
        private void ToInventory()
        {
            _playerInventory.ChangeIngredient(Ingredient);

            ChangeIngredient(null);
        }
        
    }
}