using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    public class Ingredient : MonoBehaviour
    {
        public IngredientInfo IngredientInfo { get; set; }

        public void SetIngredientInfo(IngredientInfo ingredientInfo)
        {
            IngredientInfo = ingredientInfo;
        }
    }
}