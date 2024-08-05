using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    public class Ingredient : IIngredient
    {
        public IngredientInfo IngredientInfo { get; set; }

        public Ingredient(IngredientInfo ingredientInfo)
        {
            IngredientInfo = ingredientInfo;
        }
    }
}