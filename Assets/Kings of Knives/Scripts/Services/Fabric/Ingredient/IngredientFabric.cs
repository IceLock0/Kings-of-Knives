using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Kings_of_Knives.Scripts.Services.Fabric.Ingredient
{
    public class IngredientFabric : IIngredientFabric
    {
        private const string INGREDIENTS_PATH = "INGREDIENTS";

        private List<GameObject> _allIngredients = new List<GameObject>();
        private DiContainer _container;
        
        public IngredientFabric(DiContainer container)
        {
            _container = container;
            Load();
        }

        public void Load()
        {
            _allIngredients.AddRange(Resources.LoadAll<GameObject>(INGREDIENTS_PATH));
        }

        public Scripts.Ingredient CreateIngredientFromSO(IngredientInfo ingredientInfo, Vector3 at, Transform parent = null)
        {
            if (ingredientInfo == null)
                return default;
            
            if (!_allIngredients.Contains(ingredientInfo.Prefab))
                throw new ArgumentException("The provided prefab does not exist in the loaded list.");
            
            var createdGO = _container.InstantiatePrefab(ingredientInfo.Prefab, at, Quaternion.identity, parent);

            var createdIngredient = createdGO.AddComponent<Scripts.Ingredient>();
            
            createdIngredient.SetIngredientInfo(ingredientInfo);

            return createdIngredient;

        }
    }
}