using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    [CreateAssetMenu(fileName = "IngredientFryingInfo", menuName = "Scriptable Objects/Ingredients/IngredientFryingInfo")]
    public class IngredientFryingInfo : IngredientInfo
    {
        [SerializeField] private float _timeToFrying;

        public float TimeToFrying => _timeToFrying;
    }
}