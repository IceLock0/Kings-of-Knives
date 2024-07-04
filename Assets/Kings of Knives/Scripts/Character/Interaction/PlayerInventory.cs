using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Character
{
    public class PlayerInventory
    {
        private static PlayerInventory _instance;

        private PlayerInventory()
        {
        }

        public static PlayerInventory GetInstance()
        {
            if (_instance == null)
                _instance = new PlayerInventory();
            return _instance;
        }
        
        
        public event Action PlayerInventoryChanged;

        private IIngredient _ingredient;

        public void SetIngredient(IIngredient ingredient)
        {
            _ingredient = ingredient;

            PlayerInventoryChanged?.Invoke();
        }

        public IIngredient GetIngredient()
        {
            return _ingredient;
        }
    }
}