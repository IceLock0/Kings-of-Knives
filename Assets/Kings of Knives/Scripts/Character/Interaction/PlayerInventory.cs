using System;

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
        
        private IngredientInfo _ingredient;

        public void SetIngredient(IngredientInfo ingredient)
        {
            _ingredient = ingredient;
            
            PlayerInventoryChanged?.Invoke();
        }

        public IngredientInfo GetIngredient()
        {
            return _ingredient;
        }
    }
}